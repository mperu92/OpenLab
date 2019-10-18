/* eslint-disable jsx-a11y/control-has-associated-label */
import React from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';

const NewsList = ({ newsList, onDeleteClick }) => (
    <table className="table">
        <thead>
            <tr>
                <th>Title</th>
                <th>Author</th>
                <th>Date</th>
                <th />
            </tr>
        </thead>
        <tbody>
            {newsList.length > 0 ? (
                newsList.map((n) => (
                    <tr key={n.id}>
                        <td>
                            <Link to={`news/${n.slug}`}>{n.title}</Link>
                        </td>
                        <td>{n.createUserName}</td>
                        <td>{n.publishDate}</td>
                        <td>
                            <button
                              type="button"
                              className="btn btn-outline-danger"
                              onClick={() => onDeleteClick(n)} // optimistic delete
                            >
                                Delete
                            </button>
                        </td>
                    </tr>
                ))
            ) : (
                <tr>
                    <td>
                        <h1>There&apos;s no news yet!</h1>
                    </td>
                </tr>
            )}
        </tbody>
    </table>
);

NewsList.propTypes = {
    newsList: PropTypes.arrayOf(PropTypes.object).isRequired,
    onDeleteClick: PropTypes.func.isRequired,
};

export default NewsList;
