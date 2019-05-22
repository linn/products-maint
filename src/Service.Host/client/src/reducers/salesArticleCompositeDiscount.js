import { itemStoreFactory } from '@linn-it/linn-form-components-library';
import { salesArticleCompositeDiscountActionTypes as actionTypes } from '../actions';
import * as itemTypes from '../itemTypes';

const defaultState = {
    loading: false,
    item: null
};

export default itemStoreFactory(
    itemTypes.salesArticleCompositeDiscount.actionType,
    actionTypes,
    defaultState
);
