import { salesArticleActionTypes as actionTypes } from '../actions';
import itemStoreFactory from './reducerFactories/itemStoreFactory';
import * as itemTypes from '../itemTypes';

const defaultState = {
    loading: false,
    item: null
}

export default itemStoreFactory(itemTypes.salesArticle.actionType, actionTypes, defaultState);
