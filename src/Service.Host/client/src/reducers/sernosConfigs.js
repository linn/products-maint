﻿import { sernosConfigsActionTypes as actionTypes } from '../actions';
import collectionStoreFactory from './reducerFactories/collectionStoreFactory';
import * as itemTypes from '../itemTypes';

const defaultState = {
    loading: false,
    items: []
}

export default collectionStoreFactory(itemTypes.sernosConfigs.actionType, actionTypes, defaultState);