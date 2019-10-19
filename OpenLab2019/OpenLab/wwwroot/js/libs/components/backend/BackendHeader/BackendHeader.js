/* eslint-disable no-unused-vars */
import React from 'react';
import PropTypes from 'prop-types';
import { NavLink } from 'react-router-dom';

const activeStyle = { color: '#F1B2A' };

const BackendHeader = ({ User, IsLogged, IsAdminRole }) => (
    <header id="ol-backend-header">
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
                            <a className="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
                        </li>
                        <li className="nav-item">
                            <NavLink className="nav-link text-dark" to="/Backoffice/Dashboard/Index" activeStyle={activeStyle}>
                                BACKOFFICE DASHBOARD
                            </NavLink>
                        </li>
                        {IsAdminRole && (
                            <NavLink className="nav-link text-dark" to="/Backoffice/Dashboard/Users/List" activeStyle={activeStyle}>
                                MANAGE USERS
                            </NavLink>
                        )}
                            <NavLink className="nav-link text-dark" to="/Backoffice/Dashboard/News/List" activeStyle={activeStyle}>
                                MANAGE NEWS
                            </NavLink>
                    </ul>
                    <ul className="navbar-nav ml-auto">
                        <li className="nav-item">
                            <a href="#" className="nav-link text-dark">{User.UserName}</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>
    // <header>
    //     <nav className="navbar navbar-expand-lg fixed-top">
    //         <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
    //             <span>
    //                 <i className="material-icons">menu</i>
    //             </span>
    //         </button>
    //         <div className="collapse navbar-collapse header-collapse" id="navbarNav">
    //             <ul className="navbar-nav mx-auto collapse-ul">
    //                 <li className="nav-item active">
    //                     <Link to="/">
    //                         BACKOFFICE DASHBOARD
    //                     </Link>
    //                 </li>
    //                 <li className="nav-item">
    //                     {IsAdminRole && (
    //                         <Link to="/">
    //                             MANAGE USERS
    //                         </Link>
    //                     )}
    //                 </li>
    //                 <li className="nav-item">
    //                     <Link to="news/list">
    //                         MANAGE NEWS
    //                     </Link>
    //                 </li>
    //             </ul>
    //             <ul className="navbar-nav float-right signin-area">
    //                 <li className="nav-item dropdown user-space">
    //                     <span>{User.UserName}</span>
    //                 </li>
    //             </ul>
    //         </div>
    //     </nav>
    // </header>
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
