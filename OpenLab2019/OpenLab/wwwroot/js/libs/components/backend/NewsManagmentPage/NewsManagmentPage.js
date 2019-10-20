/* eslint-disable react/destructuring-assignment */
/* eslint-disable no-shadow */

// this is just another way to do things
// (functional React component && React Hooks)
import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { toast } from 'react-toastify';
import { message } from 'antd';
import sanitizeHtml from 'sanitize-html';

import { loadNewsList, saveNews } from '../../../redux/actions/newsActions';
import { uploadImage } from '../../../redux/actions/commonActions';
import NewsForm from './NewsForm';
import Spinna from '../../common/Spinna';

const newNews = {
    id: 0,
    slug: '',
    title: '',
    abstract: '',
    bodyHtml: '',
    bodyText: '',
    imageUrl: '',
    niceLink: '',
    publishDate: Date.now,
};

export function NewsManagmentPage({
    newsList,
    loadNewsList,
    saveNews,
    uploadImage,
    history,
    ...props
}) {
    const [news, setNews] = useState({ ...props.news });
    const [errors, setErrors] = useState({});
    const [saving, setSaving] = useState(false);
    const [savingFile, setSavingFile] = useState(false);

    useEffect(() => {
        if (newsList.length === 0) {
            try {
                loadNewsList(false);
            } catch (error) {
                if (error) {
                    toast.error(error);
                } else {
                    toast.error('error loading news');
                }
            }
        } else {
            setNews({ ...props.news });
        }
    }, [props.news]);

    function formIsValid() {
        const {
            title,
            abstract,
            bodyHtml,
            imageUrl,
        } = news;
        const errors = {};

        if (!title) errors.Title = 'Title is required';
        if (!abstract) errors.Abstract = 'Abstract is required';
        if (!bodyHtml) errors.BodyHtml = 'Body is required';
        if (!imageUrl) errors.ImageUrl = 'News cover image is required';

        setErrors(errors);

        // form is valid if errors object still has no props
        return Object.keys(errors).length === 0;
    }

    function handleChange(event) {
        const { name, value } = event.target;
        setNews((prevNews) => ({
            ...prevNews,
            [name]: value,
        }));
    }

    function handleChangeEditor(content, name) {
        debugger;
        const contentWithBrSpaced = content.replace(/<br\s*\/?>/gi, '  ');
        const bodyText = sanitizeHtml(contentWithBrSpaced, { allowedTags: [], allowedAttributes: {} });
        setNews((prevNews) => ({
            ...prevNews,
            bodyText,
            [name]: content,
        }));
    }

    // to do
    function handleChangeUploader(info) {
        if (info.file.status !== 'uploading') {
            console.log(info.file, info.fileList);
        }
        if (info.file.status === 'done') {
            message.success(`${info.file.name} file uploaded successfully`);

            // TO FIX
            setNews((prevNews) => ({
                ...prevNews,
                [info]: info,
            }));
        } else if (info.file.status === 'error') {
            message.error(`${info.file.name} file upload failed.`);
        }
    }

    function handleUploadFile(file) {
        if (file) {
            setSavingFile(true);
            uploadImage(file, 'news')
            .then(() => {
                toast.success('Image uploaded');
            })
            .catch((error) => {
                setSavingFile(false);
                setErrors({ onSaveFile: error.message });
            });
        }
    }

    function handleSave(event) {
        event.preventDefault();
        if (!formIsValid()) return;
        setSaving(true);
        saveNews(news)
        .then(() => {
            toast.success('News saved');
            history.push('/Backoffice/Dashboard/News/list');
        })
        .catch((error) => {
            setSaving(false);
            setErrors({ onSave: error.message });
        });
    }

    return news.length === 0 ? (
        <Spinna />
    ) : (
        <NewsForm
          news={news}
          errors={errors}
          onChange={handleChange}
          onChangeEditor={handleChangeEditor}
          onChangeUploader={handleChangeUploader}
          onSave={handleSave}
          onSaveFile={handleUploadFile}
          saving={saving}
          savingFile={savingFile}
        />
    );
}

NewsManagmentPage.propTypes = {
    news: PropTypes.shape({
        id: PropTypes.number,
        slug: PropTypes.string,
        title: PropTypes.string,
        abstract: PropTypes.string,
        bodyHtml: PropTypes.string,
        bodyText: PropTypes.string,
        imageUrl: PropTypes.string,
        niceLink: PropTypes.string,
        // to fix
        // eslint-disable-next-line react/forbid-prop-types
        publishDate: PropTypes.any,
        createUserName: PropTypes.string,
        createUserId: PropTypes.number,
        updateUserName: PropTypes.string,
        updateUserId: PropTypes.number,
    }).isRequired,
    newsList: PropTypes.arrayOf(PropTypes.object).isRequired,
    loadNewsList: PropTypes.func.isRequired,
    saveNews: PropTypes.func.isRequired,
    uploadImage: PropTypes.func.isRequired,
    // eslint-disable-next-line react/forbid-prop-types
    history: PropTypes.object.isRequired,
};

// redux selector
export function getNewsBySlug(newsList, slug) {
    return newsList.find((n) => n.slug === slug) || null;
}

function mapStateToProps(state, ownProps) {
    const { match: { params: { slug } } } = ownProps; // .match.params.slug;
    const news = slug && state.newsList.length > 0 ? getNewsBySlug(state.newsList, slug) : newNews;
    return {
        news,
        newsList: state.newsList,
    };
}

const mapDispatchToProps = {
    loadNewsList,
    saveNews,
    uploadImage,
};

export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(NewsManagmentPage);
