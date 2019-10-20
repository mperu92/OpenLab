import * as types from '../actions/actionTypes';
import initialState from './initialState';

export default function newsReducer(state = initialState.newsList, action) {
  switch (action.type) {
    case types.LOAD_NEWS_SUCCESS:
      // state.push(action.course); <= don't do this. this mutates state.
      return action.newsList;
    case types.CREATE_NEWS_SUCCESS:
      // Whatever is returned from the reducer becomes the new state.
      // Use the spread operator to clone the state so to create a new obj
      return [...state, { ...action.news }];
    case types.UPDATE_NEWS_SUCCESS:
      return state.map((news) => (news.id === action.news.id ? action.news : news));
    case types.DELETE_NEWS_OPTIMISTIC:
      return state.filter((news) => news.id !== action.news.id);
    case types.UPLOAD_FILE_NEWS_SUCCESS:
      return { ...action.file.data };
    default:
      // If the reducer receives an action that it doesn't care about
      // it should return the unchanged state
      return state;
  }
  // See Normalizing State Shape in Redux docs
}
