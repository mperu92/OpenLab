import * as types from '../actions/actionTypes';
import initialState from './initialState';

export default function newsReducer(state = initialState, action) {
  switch (action.type) {
    case types.UPLOAD_FILE_SUCCESS:
      return state;
    default:
      return state;
  }
}
