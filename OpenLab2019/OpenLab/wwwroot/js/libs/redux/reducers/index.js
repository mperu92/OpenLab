// root reducer
import { combineReducers } from 'redux';
import apiCallsInProgress from './apiStatusReducer';
import newsList from './newsReducer';

const rootReducer = combineReducers({
  apiCallsInProgress,
  newsList,
});

export default rootReducer;
