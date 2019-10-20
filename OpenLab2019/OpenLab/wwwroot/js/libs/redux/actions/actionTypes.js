export const BEGIN_API_CALL = 'BEGIN_API_CALL';
export const API_CALL_ERROR = 'API_CALL_ERROR';
export const LOAD_NEWS_SUCCESS = 'LOAD_NEWS_SUCCESS';
export const CREATE_NEWS_SUCCESS = 'CREATE_NEWS_SUCCESS';
export const UPDATE_NEWS_SUCCESS = 'UPDATE_NEWS_SUCCESS';
export const UPLOAD_FILE_SUCCESS = 'UPLOAD_FILE_SUCCESS';
export const UPLOAD_FILE_NEWS_SUCCESS = 'UPLOAD_FILE_NEWS_SUCCESS';

// By convention, actions that end in "_SUCCESS" are assumed to have been the result of a completed
// API call. But since we're doing an optimistic delete, we're hiding loading state.
// So this action name deliberately omits the "_SUCCESS" suffix.
// If it had one, our apiCallsInProgress counter would be decremented below zero
// because we're not incrementing the number of apiCallInProgress when the delete request begins.
// export const DELETE_{0}_OPTIMISTIC = 'DELETE_{0}_OPTIMISTIC';
export const DELETE_NEWS_OPTIMISTIC = 'DELETE_COURSE_OPTIMISTIC';
