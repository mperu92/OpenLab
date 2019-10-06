/* eslint-disable import/prefer-default-export */
import axios from 'axios';
import * as types from './actionTypes';
import { beginApiCall, apiCallError } from './apiStatusActions';

export function loadNewsListSuccess(newsList) {
    return { type: types.LOAD_NEWS_SUCCES, newsList };
}

export function createNewsSuccess(news) {
    return { type: types.CREATE_NEWS_SUCCES, news };
}

export function updateNewsSuccess(news) {
    return { type: types.UPDATE_NEWS_SUCCESS, news };
}

export function deleteNewsOptimistic(news) {
    return { type: types.DELETE_NEWS_OPTIMISTIC, news };
}

// thunk (test async)
export async function loadNewsList() {
    debugger;
    return async (dispatch) => {
        dispatch(beginApiCall());
        await axios.post('/api/newsApi/getNewsList')
        .then(({ data: { newsList } }) => {
            if (newsList && newsList !== undefined && newsList !== null) {
                dispatch(loadNewsListSuccess(newsList));
            } else {
                const error = Error.apply('error while loading news list.');
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
export function saveNews(news) {
    debugger;
    return (dispatch, getState) => {
        dispatch(beginApiCall());
        return axios.post('/api/newsApi/createUpdateNews', { news })
        .then(({ data: { _news } }) => {
            if (_news && _news !== undefined && _news !== null) {
                news.id
                ? dispatch(updateNewsSuccess(_news))
                : dispatch(createNewsSuccess(_news));
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
export function deleteNews(news) {
    debugger;
    return (dispatch) => {
        // Doin' optimisic delete, so not dispatching begin/end api call
        // actions, or apiCallError action since we're not showing the loading status for this.
        dispatch(deleteNewsOptimistic(news));
        return axios.post('/api/newsApi/deleteNews')
        .then(({ data: { deleted } }) => {
            if (!deleted || deleted === undefined || deleted === null) {
                const error = Error.apply('error while deleting news.');
                // dispatch(apiCallError(error));
                throw error;
            }
        })
        .catch((error) => {
            // dispatch(apiCallError(error));
            throw error;
        });
    };
}
