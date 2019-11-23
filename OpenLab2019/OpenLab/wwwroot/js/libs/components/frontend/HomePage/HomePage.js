import React from 'react';
import PropTypes from 'prop-types';

const HomePage = ({ SuccessMessage, ErrorMessage }) => (
  <>
  {SuccessMessage && SuccessMessage !== '' && (
    <div className="alert alert-success">
      {SuccessMessage}
    </div>
  )}
  {ErrorMessage && ErrorMessage !== '' && (
    <div className="alert alert-danger">
      {ErrorMessage}
    </div>
  )}
  <div className="jumbotron">
    <h1>OpenLab</h1>
    <p>
      Welcome
      {/* {IsAdminRole && (' and users')} */}
    </p>
  </div>
  </>
);

HomePage.propTypes = {
  SuccessMessage: PropTypes.string.isRequired,
  ErrorMessage: PropTypes.string.isRequired,
};

export default HomePage;
