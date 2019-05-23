import { itemStoreFactory } from '@linn-it/linn-form-components-library';
import { serialNumberTransactionActionTypes as actionTypes } from '../actions';
import * as itemTypes from '../itemTypes';

const defaultState = {
    loading: false,
    sernosTransCodes: null,
    editStatus: 'view'
};

export default itemStoreFactory(
    itemTypes.serialNumberTransaction.actionType,
    actionTypes,
    defaultState
);
