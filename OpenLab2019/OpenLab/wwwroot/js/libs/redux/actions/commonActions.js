/* eslint-disable import/prefer-default-export */
import axios from 'axios';
import * as types from './actionTypes';
import { beginApiCall, apiCallError } from './apiStatusActions';
import { dispatch } from 'C:/Users/m.peru.SOLUTIONFACTORY/AppData/Local/Microsoft/TypeScript/3.6/node_modules/rxjs/internal/observable/pairs';

export function clearCommonSuccess(data) {
    return { type: types.CLEAR_COMMON_SUCCESS, data };
}

export function uploadImageSuccess(file) {
    return { type: types.UPLOAD_FILE_SUCCESS, file };
}

export function uploadImageNewsSuccess(file) {
    return { type: types.UPLOAD_FILE_NEWS_SUCCESS, file };
}

export function deleteImageSuccess(value) {
    return { type: types.DELETE_FILE_SUCCESS, value };
}

export function deleteImageNewsSuccess(value) {
    return { type: types.DELETE_FILE_NEWS_SUCCESS, value };
}

// thunk
export function clearCommon() {
    return (dispatch) => {
        const data = {};
        dispatch(clearCommonSuccess(data));
    };
}

// thunk
export function uploadImage(file, fromContent) {
    const fd = new FormData();
    fd.append('file', file);

    return (dispatch) => { // , getState
        dispatch(beginApiCall());
        return axios.post('/api/CommonApi/uploadImage', fd, {
            headers: {
                'Content-Type': 'multipart/form-data',
                authorization: 'authorization-text',
            },
        })
        .then(({ data }) => {
            if (data) {
                switch (fromContent) {
                    case 'news':
                        dispatch(uploadImageNewsSuccess(data));
                        break;
                    default:
                        dispatch(uploadImageSuccess(data));
                        break;
                }
            } else {
                const error = Error.apply('error while creating - updating news.');
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

// thunk
export function deleteImage(value, fromContent) {
    return (dispatch) => { // , getState
        dispatch(beginApiCall());
        return axios.post('/api/CommonApi/deleteImage', { value })
        .then(({ data }) => {
            if (data) {
                switch (fromContent) {
                    case 'news':
                        dispatch(deleteImageNewsSuccess(data));
                        break;
                    default:
                        dispatch(deleteImageSuccess(data));
                        break;
                }
            } else {
                const error = Error.apply('error while deleting news.');
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


// ### ACCOUNT ###
// export function loginUser(value) {
//     return (dispatch) => {
//         dispatch(beginApiCall());
//         return axios.post('/api/AccountApi/')
//     };
// }