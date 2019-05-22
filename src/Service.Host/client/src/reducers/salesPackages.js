import { paginationStoreFactory } from '@linn-it/linn-form-components-library';
import { salesPackagesActionTypes as actionTypes } from '../actions';
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
