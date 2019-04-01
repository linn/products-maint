import { salesPackagesActionTypes as actionTypes } from '../actions';
import collectionStoreFactory from './reducerFactories/collectionStoreFactory';
import * as itemTypes from '../itemTypes';

const defaultState = {
    loading: false,
    items: [],
    searchItems: []
};

export default collectionStoreFactory(
    itemTypes.salesPackages.actionType,
    actionTypes,
    defaultState
);
