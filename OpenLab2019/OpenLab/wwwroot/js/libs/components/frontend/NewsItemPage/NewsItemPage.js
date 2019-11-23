/* eslint-disable react/destructuring-assignment */
/* eslint-disable no-shadow */
import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { toast } from 'react-toastify';
import { withRouter } from 'react-router-dom';
// import { message } from 'antd';
// import sanitizeHtml from 'sanitize-html';

import { loadNewsList } from '../../../redux/actions/newsActions';
// import { uploadImage, deleteImage } from '../../../redux/actions/commonActions';
import NewsItem from './NewsItem';
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

export function NewsItemPage({
    newsList,
    common,
    loadNewsList,
    history,
    ...props
}) {
    const [news, setNews] = useState({ ...props.news });

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

    return news.length === 0 ? (
        <Spinna />
    ) : (
        <NewsItem
          news={news}
        />
    );
}

NewsItemPage.propTypes = {
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
    common: PropTypes.shape({
        file: PropTypes.object,
    }).isRequired,
    newsList: PropTypes.arrayOf(PropTypes.object).isRequired,
    loadNewsList: PropTypes.func.isRequired,
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
        common: state.common || {},
    };
}

const mapDispatchToProps = {
    loadNewsList,
};

export default withRouter(connect(
    mapStateToProps,
    mapDispatchToProps,
)(NewsItemPage));
