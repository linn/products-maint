import { serialNumberActionTypes as actionTypes } from '../actions';
import itemStoreFactory from './reducerFactories/itemStoreFactory';
import * as itemTypes from '../itemTypes';

const defaultState = {
    loading: false,
    item: null,
    editStatus: 'view'
};

export default itemStoreFactory(itemTypes.serialNumber.actionType, actionTypes, defaultState);
