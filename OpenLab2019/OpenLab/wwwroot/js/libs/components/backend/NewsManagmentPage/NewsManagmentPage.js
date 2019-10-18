/* eslint-disable react/destructuring-assignment */
/* eslint-disable no-shadow */

// this is just another way to do things
// (functional React component && React Hooks)
import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { toast } from 'react-toastify';

import { loadNewsList, saveNews } from '../../../redux/actions/newsActions';
import NewsForm from './NewsForm';
import Spinna from '../../common/Spinna';

const newNews = {
    Id: 0,
    Slug: '',
    Title: '',
    Abstract: '',
    BodyHtml: '',
    BodyText: '',
    ImageUrl: '',
    NiceLink: '',
    PublishDate: Date.now,
};

export function NewsManagmentPage({
    newsList,
    loadNewsList,
    saveNews,
    history,
    ...props
}) {
    const [news, setNews] = useState({ ...props.news });
    const [errors, setErrors] = useState({});
    const [saving, setSaving] = useState(false);

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

            // loadNewsList().catch((error) => {
            //     toast.error(`Loading news failed ${error}`);
            // });
        } else {
            setNews({ ...props.news });
        }
    }, [props.news]);

    function formIsValid() {
        const { Title, Abstract, BodyHtml } = news;
        const errors = {};

        if (!Title) errors.Title = 'Title is required';
        if (!Abstract) errors.Abstract = 'Abstract is required';
        if (!BodyHtml) errors.BodyHtml = 'Body is required';

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

    function handleSave(event) {
        event.preventDefault();
        if (!formIsValid()) return;
        setSaving(true);
        saveNews(news)
        .then(() => {
            toast.success('News saved');
            history.push('/news/list');
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
          onSave={handleSave}
          saving={saving}
        />
    );
}

NewsManagmentPage.propTypes = {
    news: PropTypes.shape({
        Id: PropTypes.number,
        Slug: PropTypes.string,
        Title: PropTypes.string,
        Abstract: PropTypes.string,
        BodyHtml: PropTypes.string,
        BodyText: PropTypes.string,
        ImageUrl: PropTypes.string,
        NiceLink: PropTypes.string,
        PublishDate: PropTypes.func,
        CreateUserName: PropTypes.string,
    }).isRequired,
    newsList: PropTypes.arrayOf(PropTypes.object).isRequired,
    loadNewsList: PropTypes.func.isRequired,
    saveNews: PropTypes.func.isRequired,
    // eslint-disable-next-line react/forbid-prop-types
    history: PropTypes.object.isRequired,
    // history: PropTypes.arrayOf(PropTypes.string).isRequired,
};

// redux selector
export function getNewsBySlug(newsList, slug) {
    return newsList.find((n) => n.Slug === slug) || null;
}

function mapStateToProps(state, ownProps) {
    const { match: { params: { Slug } } } = ownProps; // .match.params.slug;
    const news = Slug && state.newsList.length > 0 ? getNewsBySlug(state.newsList, Slug) : newNews;
    return {
        news,
        newsList: state.newsList,
    };
}

const mapDispatchToProps = {
    loadNewsList,
    saveNews,
};

export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(NewsManagmentPage);
