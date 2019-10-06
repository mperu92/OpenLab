import React from 'react';
import { BrowserRouter as Router } from 'react-router-dom';
import { Provider as ReduxProvider } from 'react-redux';
import reactDom from '../../../common/react/dom/index';
import configureStore from '../../../redux/configureStore';

import DashboardContainer from '../../../components/backend/DashboardContainer';

let userObj = {};
const UserString = __globalJsData.user;
const IsLogged = !!(__globalJsData.isLogged && __globalJsData.isLogged === 1);
const IsAdminRole = !!(__globalJsData.isAdminRole && __globalJsData.isAdminRole === 1);

if (UserString && UserString !== '') {
  userObj = JSON.parse(UserString);
}

const store = ConfigureStore();

export default function init() {
    ReactDom(
        <ReduxProvider store={store}>
            <Router>
                <DashboardContainer
                  IsLogged={IsLogged}
                  IsAdminRole={IsAdminRole}
                  User={userObj}
                />
            </Router>
        </ReduxProvider>,
        'js-backoffice',
    );
}
