import { createStore, applyMiddleware, compose } from 'redux';
import thunk from 'redux-thunk';

import rootReducer from './reducers';

export default function configureStore(initialState) {
    return createStore(rootReducer, initialState, applyMiddleware(thunk));
}


// Redux Middleware is a way to enhance Redux's behavior
// with extra functionalities
