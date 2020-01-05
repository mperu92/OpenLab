/* eslint-disable no-undef */
import { createStore } from 'redux';
import rootReducer from './reducers';
import initialState from './reducers/initialState';
import * as newsActions from './actions/newsActions';

it('Shoulde handle creating news', () => {
    // arrange
    const store = createStore(rootReducer, initialState);
    const news = {
        id: 2,
    };
    // act
    const action = newsActions.createNewsSuccess(news);
    store.dispatch(action);
    // assert
    const createdNews = store.getState().newsList[0];
    expect(createdNews).toEqual(news);
});
