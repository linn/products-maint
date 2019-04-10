import { salesPackagesActionTypes as actionTypes } from '../actions';
import paginationStoreFactory from './reducerFactories/paginationStoreFactory';
import * as itemTypes from '../itemTypes';

const defaultState = {
    loading: false,
    page: { elements: [], pageNumber: 1, pageSize: 5 }
};

export default paginationStoreFactory(
    itemTypes.salesPackages.actionType,
    actionTypes,
    defaultState
);
