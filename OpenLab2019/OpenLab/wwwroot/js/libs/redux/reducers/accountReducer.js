import * as types from '../actions/actionTypes';
import initialState from './initialState';

export default function accountReducer(state = initialState.userInfo, action) {
    switch (action.type) {
        case types.ACCOUNT_LOGIN_SUCCESS:
            return action.userInfo;
        case types.ACCOUNT_LOGOFF_SUCCESS:
            return action.userInfo;
        case types.ACCOUNT_REGISTER_SUCCESS:
            return action.userInfo;
        default:
            return state;
    }
}
