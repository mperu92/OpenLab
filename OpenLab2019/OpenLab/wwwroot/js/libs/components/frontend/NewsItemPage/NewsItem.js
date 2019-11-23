import React from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
// import SelectInput from '../../common/SelectInput';

const NewsItem = ({
  news,
}) => (
    <div className="row">
        <div className="col-12 news-item-container">
            <div className="col-12 col-md-2">
                <img alt={news.title} src={news.imageUrl} className="img-fluid" />
            </div>
            <div className="col-12 col-md-10">
                <h3>{news.title}</h3>
                <h5>{news.abstract}</h5>
                <br />
                <span dangerouslySetInnerHTML={{ __html: news.bodyHtml }} />
            </div>
        </div>
        <Link to="/News" className="btn btn-outline-info">News List</Link>
    </div>
);

NewsItem.propTypes = {
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
};

export default NewsItem;
