import { salesPackagesActionTypes as actionTypes } from '../actions';
import collectionStoreFactory from './reducerFactories/collectionStoreFactory';
import * as itemTypes from '../itemTypes';

const defaultState = {
    loading: false,
    items: [],
    searchItems: [],
    rowsPerPage: 5,
    page: 0
};

export default collectionStoreFactory(
    itemTypes.salesPackages.actionType,
    actionTypes,
    defaultState
);
