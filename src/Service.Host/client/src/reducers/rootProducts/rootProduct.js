import { itemStoreFactory } from '@linn-it/linn-form-components-library';
import { rootProductActionTypes as actionTypes } from '../../actions';
import * as itemTypes from '../../itemTypes';

const defaultState = {
    loading: false,
    item: null
};

export default itemStoreFactory(itemTypes.rootProduct.actionType, actionTypes, defaultState);
