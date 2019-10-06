import React from 'react';
import PropTypes from 'prop-types';

const HomePage = ({ IsAdminRole }) => (
  <div className="jumbotron">
    <h1>OpenLab Backoffice Dashboard</h1>
    <p>
      Manage content
      {IsAdminRole && (' and users')}
    </p>
  </div>
);

HomePage.propTypes = {
  IsAdminRole: PropTypes.bool.isRequired,
};

export default HomePage;
