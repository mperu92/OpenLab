// root reducer
import { combineReducers } from 'redux';
import apiCallsInProgress from './apiStatusReducer';
import news from './newsReducer';

const rootReducer = combineReducers({
  apiCallsInProgress,
  news,
});

export default rootReducer;
