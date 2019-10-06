/* eslint-disable no-unused-vars */
import React from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';

const BackendHeader = ({ User, IsLogged, IsAdminRole }) => (
    <header>
        <nav className="navbar navbar-expand-lg fixed-top">
            <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span>
                    <i className="material-icons">menu</i>
                </span>
            </button>
            <div className="collapse navbar-collapse header-collapse" id="navbarNav">
                <ul className="navbar-nav mx-auto collapse-ul">
                    <li className="nav-item active">
                        <Link to="/">
                            BACKOFFICE DASHBOARD
                        </Link>
                    </li>
                    <li className="nav-item">
                        {IsAdminRole && (
                            <Link to="/">
                                MANAGE USERS
                            </Link>
                        )}
                    </li>
                    <li className="nav-item">
                        <Link to="news/list">
                            MANAGE NEWS
                        </Link>
                    </li>
                </ul>
                <ul className="navbar-nav float-right signin-area">
                    <li className="nav-item dropdown user-space">
                        <span>{User.UserName}</span>
                    </li>
                </ul>
            </div>
        </nav>
    </header>
);

BackendHeader.propTypes = {
    User: PropTypes.shape({
        Id: PropTypes.number,
        UserName: PropTypes.string,
    }).isRequired,
    IsLogged: PropTypes.bool.isRequired,
    IsAdminRole: PropTypes.bool.isRequired,
};

export default BackendHeader;
