// root reducer
import { combineReducers } from 'redux';
import apiCallsInProgress from './apiStatusReducer';
import newsList from './newsReducer';
import commons from './commonReducer';

const rootReducer = combineReducers({
  apiCallsInProgress,
  commons,
  newsList,
});

export default rootReducer;
