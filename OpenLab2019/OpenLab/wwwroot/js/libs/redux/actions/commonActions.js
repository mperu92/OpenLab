/* eslint-disable import/prefer-default-export */
import axios from 'axios';
import * as types from './actionTypes';
import { beginApiCall, apiCallError } from './apiStatusActions';

export function uploadImageSuccess(file) {
    return { type: types.UPLOAD_FILE_SUCCESS, file };
}

export function uploadImageNewsSuccess(file) {
    return { type: types.UPLOAD_FILE_NEWS_SUCCESS, file };
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
