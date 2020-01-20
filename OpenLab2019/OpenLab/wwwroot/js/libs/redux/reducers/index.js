// root reducer
import { combineReducers } from 'redux';
import apiCallsInProgress from './apiStatusReducer';
import newsList from './newsReducer';
import common from './commonReducer';
import userInfo from './accountReducer';

const rootReducer = combineReducers({
  apiCallsInProgress,
  common,
  newsList,
  userInfo,
});

export default rootReducer;
