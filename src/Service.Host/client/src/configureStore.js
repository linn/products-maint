﻿import { createStore, applyMiddleware, compose } from 'redux';
import { apiMiddleware as api } from 'redux-api-middleware';
import { createBrowserHistory } from 'history';
import thunkMiddleware from 'redux-thunk';
import reducer from './reducers';
import authorization from './middleware/authorization';
import itemCreated from './middleware/itemCreated';
import serialNumbers from './middleware/serialNumbers';

// eslint-disable-next-line no-underscore-dangle
const composeEnhancers =
    (window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ &&
        window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__({ trace: true, traceLimit: 25 })) ||
    compose;

const middleware = [authorization, api, thunkMiddleware, itemCreated, serialNumbers];

export const history = createBrowserHistory();

const configureStore = initialState => {
    const enhancers = composeEnhancers(applyMiddleware(...middleware));
    const store = createStore(reducer(history), initialState, enhancers);

    return store;
};

export default configureStore;
