import { rootProductsActionTypes as actionTypes } from '../../actions';
import collectionStoreFactory from '../reducerFactories/collectionStoreFactory';
import * as itemTypes from '../../itemTypes';

const defaultState = {
    loading: false,
    items: [],
    searchItems: []
};

export default collectionStoreFactory(itemTypes.rootProducts.actionType, actionTypes, defaultState);
