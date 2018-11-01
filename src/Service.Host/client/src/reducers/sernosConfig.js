import { sernosConfigActionTypes as actionTypes } from '../actions';
import itemStoreFactory from './reducerFactories/itemStoreFactory';

const defaultState = {
    loading: false,
    item: null,
    editStatus: 'view'
}

export default itemStoreFactory('SERNOS_CONFIG', actionTypes, defaultState);
