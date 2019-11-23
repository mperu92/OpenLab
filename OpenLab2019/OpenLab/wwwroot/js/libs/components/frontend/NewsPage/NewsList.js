/* eslint-disable jsx-a11y/control-has-associated-label */
import React from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';

const NewsList = ({ newsList }) => (
    <div className="col-12">
        <div className="news-list-items-container lh-0-5">
            {newsList.map((n) => (
                <div key={n.id} className="news-list-item">
                    <Link to={`/SingleNews/${n.slug}`}>
                        <h4>{n.title}</h4>
                    </Link>
                    <p>{n.abstract}</p>
                </div>
            ))}
        </div>
    </div>
);

NewsList.propTypes = {
    newsList: PropTypes.arrayOf(PropTypes.object).isRequired,
};

export default NewsList;
