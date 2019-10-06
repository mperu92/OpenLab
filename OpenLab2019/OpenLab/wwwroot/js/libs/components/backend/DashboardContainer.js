import React from 'react';
import PropTypes from 'prop-types';
import { Route, Switch } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';

import BackendHeader from './BackendHeader';
import PageNotFound from './PageNotFound';
import HomePage from './HomePage';
import NewsPage from './NewsPage';
import NewsManagmentPage from './NewsManagmentPage';

debugger;

const DashboardContainer = ({ User, IsLogged, IsAdminRole }) => (
    <div className="container">
        <BackendHeader User={User} IsLogged={IsLogged} IsAdminRole={IsAdminRole} />
        <Switch>
            <Route exact path="/Backoffice/Dashboard/Index" component={HomePage} IsAdminRole={IsAdminRole} />
            <Route path="/news/list" component={NewsPage} />
            <Route path="/news/:slug" component={NewsManagmentPage} />
            <Route path="/news" component={NewsManagmentPage} />
            <Route component={PageNotFound} />
        </Switch>
        <ToastContainer autoClose={3000} hideProgressBar />
    </div>
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
