import { itemStoreFactory } from '@linn-it/linn-form-components-library';
import { tariffsReallocateActionTypes as actionTypes } from '../actions';
import * as itemTypes from '../itemTypes';

const defaultState = {
    loading: false,
    items: [],
    searchItems: []
};

export default itemStoreFactory(itemTypes.TariffsReallocate.actionType, actionTypes, defaultState);
