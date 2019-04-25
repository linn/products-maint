import { salesArticleCompositeDiscountActionTypes as actionTypes } from '../actions';
import itemStoreFactory from './reducerFactories/itemStoreFactory';
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