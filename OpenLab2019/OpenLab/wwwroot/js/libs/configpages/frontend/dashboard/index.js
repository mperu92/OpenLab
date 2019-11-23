import React from 'react';
import { BrowserRouter as Router } from 'react-router-dom';
import { Provider as ReduxProvider } from 'react-redux';
import reactDom from '../../../common/react/dom/index';
import configureStore from '../../../redux/configureStore';

import DashboardContainer from '../../../components/frontend/DashboardContainer';

let userObj = {};
const UserString = __globalJsData.user || '';
const IsLogged = !!(__globalJsData.isLogged && __globalJsData.isLogged === 1);
const IsAdminRole = !!(__globalJsData.isAdminRole && __globalJsData.isAdminRole === 1);

const SuccessMessage = __globalJsData.successMessage || '';
const ErrorMessage = __globalJsData.errorMessage || '';

if (UserString && UserString !== '') {
  userObj = JSON.parse(UserString);
}

const store = configureStore();

export default function init() {
  reactDom(
    <ReduxProvider store={store}>
        <Router>
            <DashboardContainer
              SuccessMessage={SuccessMessage}
              ErrorMessage={ErrorMessage}
              IsLogged={IsLogged}
              IsAdminRole={IsAdminRole}
              User={userObj}
            />
        </Router>
    </ReduxProvider>,
    'js-frontend',
  );
}
