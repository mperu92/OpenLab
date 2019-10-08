import React from 'react';
import PropTypes from 'prop-types';
import { Route, Switch } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';

import BackendHeader from './BackendHeader';
import PageNotFound from './PageNotFound';
import HomePage from './HomePage';
import NewsPage from './NewsPage';
import NewsManagmentPage from './NewsManagmentPage';

const DashboardContainer = ({ User, IsLogged, IsAdminRole }) => (
    <>
        <BackendHeader User={User} IsLogged={IsLogged} IsAdminRole={IsAdminRole} />
        <div className="container d-container">
            <Switch>
                <Route exact path="/Backoffice/Dashboard/Index" component={HomePage} />
                <Route path="/News/list" component={NewsPage} />
                <Route path="/News/:slug" component={NewsManagmentPage} />
                <Route path="/News" component={NewsManagmentPage} />
                <Route component={PageNotFound} />
            </Switch>
            <ToastContainer autoClose={3000} hideProgressBar />
        </div>
    </>
);

DashboardContainer.propTypes = {
    User: PropTypes.shape({
        Id: PropTypes.number,
        UserName: PropTypes.string,
    }).isRequired,
    IsLogged: PropTypes.bool.isRequired,
    IsAdminRole: PropTypes.bool.isRequired,
};

export default DashboardContainer;
