import { tariffsActionTypes as actionTypes } from '../actions';
import collectionStoreFactory from './reducerFactories/collectionStoreFactory';
import * as itemTypes from '../itemTypes';

const defaultState = {
    loading: false,
    items: [],
    searchItems: []
};

export default collectionStoreFactory(itemTypes.tariffs.actionType, actionTypes, defaultState);
