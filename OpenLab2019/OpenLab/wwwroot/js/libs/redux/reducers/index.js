// root reducer
import { combineReducers } from 'redux';
import apiCallsInProgress from './apiStatusReducer';
import newsList from './newsReducer';
import common from './commonReducer';

const rootReducer = combineReducers({
  apiCallsInProgress,
  common,
  newsList,
});

export default rootReducer;
