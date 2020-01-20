import axios from 'axios';
import * as types from './actionTypes';
import { beginApiCall, apiCallError } from './apiStatusActions';

export function accountLoginSuccess(userInfo) {
    return { type: types.ACCOUNT_LOGIN_SUCCESS, userInfo };
}

export function accountLogoffSuccess(userInfo) {
    return { type: types.ACCOUNT_LOGOFF_SUCCESS, userInfo };
}

export function accountRegisterSuccess(userInfo) {
    return { type: types.ACCOUNT_REGISTER_SUCCESS, userInfo };
}

export function accountLogin(model) {
    return (dispatch) => {
        dispatch(beginApiCall());
        axios.post('/api/AccountApi/login', { model })
        .then(({ data }) => {
            if (data) {
                dispatch(accountLoginSuccess(data));
            } else {
                const error = Error.apply('error while logging in.');
                dispatch(apiCallError(error));
                throw error;
            }
        })
        .catch((error) => {
            dispatch(apiCallError(error));
            throw error;
        });
    };
}

export function accountLogoff(model) {
    return (dispatch) => {
        dispatch(beginApiCall());
        axios.post('/api/AccountApi/logoff', { model })
        .then(({ data }) => {
            if (data) {
                dispatch(accountLogoffSuccess(data));
            } else {
                const error = Error.apply('error while logging off.');
                dispatch(apiCallError(error));
                throw error;
            }
        })
        .catch((error) => {
            dispatch(apiCallError(error));
            throw error;
        });
    };
}

export function accountRegister(model) {
    return (dispatch) => {
        dispatch(beginApiCall());
        axios.post('/api/AccountApi/register', { model })
        .then(({ data }) => {
            if (data) {
                dispatch(accountRegisterSuccess(data));
            } else {
                const error = Error.apply('error while registering.');
                dispatch(apiCallError(error));
                throw error;
            }
        })
        .catch((error) => {
            dispatch(apiCallError(error));
            throw error;
        });
    };
}
