import * as types from '../actions/actionTypes';
import initialState from './initialState';

export default function commonReducer(state = initialState.common, action) {
  switch (action.type) {
    case types.UPLOAD_FILE_SUCCESS:
      return state;
    case types.UPLOAD_FILE_NEWS_SUCCESS:
      return { file: { ...action.file.data } };
    case types.DELETE_FILE_SUCCESS:
      return state;
    case types.DELETE_FILE_NEWS_SUCCESS:
      return { file: { status: action.value } };
    case types.LOAD_NEWS_SUCCESS:
    case types.CREATE_NEWS_SUCCESS:
    case types.UPDATE_NEWS_SUCCESS:
    case types.DELETE_NEWS_OPTIMISTIC:
    case types.CLEAR_COMMON_SUCCESS:
        return {};
    default:
      // eslint-disable-next-line no-useless-return
      return state;
  }
}
