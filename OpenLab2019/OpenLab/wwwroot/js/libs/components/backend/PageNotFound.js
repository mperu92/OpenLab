import React from 'react';
import { Link } from 'react-router-dom';

const PageNotFound = () => (
  <div className="jumbotron">
    <h1>Oops!</h1>
    <p>Page not found</p>
    <Link to="/" className="btn btn-primary btn-lg" exact="true">
      Back Home
    </Link>
  </div>
);

export default PageNotFound;
