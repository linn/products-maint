import { itemStoreFactory } from '@linn-it/linn-form-components-library';
import { salesArticlesReallocateActionTypes as actionTypes } from '../actions';
import * as itemTypes from '../itemTypes';

const defaultState = {
    loading: false,
    items: [],
    searchItems: []
};

export default itemStoreFactory(
    itemTypes.salesArticlesReallocate.actionType,
    actionTypes,
    defaultState
);
