/* eslint-disable no-unused-vars */
import React from 'react';
import PropTypes from 'prop-types';
import { NavLink } from 'react-router-dom';

const activeStyle = { color: '#F1B2A' };

const FrontendHeader = ({ User, IsLogged, IsAdminRole }) => (
    <header id="ol-frontend-header">
        <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            <div className="container">
                <a className="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">Open Lab</a>
                <button
                  className="navbar-toggler"
                  type="button"
                  data-toggle="collapse"
                  data-target=".navbar-collapse"
                  aria-controls="navbarSupportedContent"
                  aria-expanded="false"
                  aria-label="Toggle navigation"
                >
                    <span className="navbar-toggler-icon" />
                </button>
                <div className="navbar-collapse collapse">
                    <ul className="navbar-nav">
                        <li className="nav-item">
                        <NavLink className="nav-link text-dark" to="/" activeStyle={activeStyle}>
                                Home
                        </NavLink>
                        </li>
                        {IsAdminRole && (
                            <li className="nav-item">
                                <a href="/Backoffice/Dashboard/Index" className="nav-link text-dark">
                                    BACKOFFICE DASHBOARD
                                </a>
                            </li>
                        )}
                        <NavLink className="nav-link text-dark" to="/News" activeStyle={activeStyle}>
                            NEWS
                        </NavLink>
                    </ul>
                    <ul className="navbar-nav ml-auto">
                        <li className="nav-item dropdown">
                            <a
                              className="nav-link text-dark dropdown-toggle"
                              href="#"
                              id="navbarDropdown"
                              role="button"
                              data-toggle="dropdown"
                              aria-haspopup="true"
                              aria-expanded="false"
                            >
                                {User.UserName}
                            </a>
                            <div className="dropdown-menu" aria-labelledby="navbarDropdown">
                                <p>{`Hello, ${User.UserName}`}</p>
                                <div className="dropdown-divider" />
                                <a className="dropdown-item text-dark" href="#">Exit</a>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>
);

FrontendHeader.propTypes = {
    User: PropTypes.shape({
        Id: PropTypes.number,
        UserName: PropTypes.string,
    }).isRequired,
    IsLogged: PropTypes.bool.isRequired,
    IsAdminRole: PropTypes.bool.isRequired,
};

export default FrontendHeader;
