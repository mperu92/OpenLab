import React from 'react';
import PropTypes from 'prop-types';
import { Route, Switch } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';

import FrontendHeader from './FrontendHeader';
import PageNotFound from './PageNotFound';
import HomePage from './HomePage';
import NewsPage from './NewsPage';
import NewsItemPage from './NewsItemPage';

const DashboardContainer = ({
    User,
    IsLogged,
    IsAdminRole,
    SuccessMessage,
    ErrorMessage,
}) => (
    <>
        <FrontendHeader User={User} IsLogged={IsLogged} IsAdminRole={IsAdminRole} />
        <div className="container d-container">
            <Switch>
                <Route exact path="/" render={() => <HomePage SuccessMessage={SuccessMessage} ErrorMessage={ErrorMessage} />} />
                <Route path="/News" component={NewsPage} />
                <Route path="/SingleNews/:slug" component={NewsItemPage} />
                <Route component={PageNotFound} />
            </Switch>
            <ToastContainer autoClose={3000} />
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
    SuccessMessage: PropTypes.string.isRequired,
    ErrorMessage: PropTypes.string.isRequired,
};

export default DashboardContainer;
