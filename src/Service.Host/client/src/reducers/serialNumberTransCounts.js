import { collectionStoreFactory } from '@linn-it/linn-form-components-library';
import { serialNumberTransactionCountsActionTypes as actionTypes } from '../actions';
import * as itemTypes from '../itemTypes';

const defaultState = {
    loading: false,
    items: []
};

export default collectionStoreFactory(
    itemTypes.serialNumberTransCounts.actionType,
    actionTypes,
    defaultState
);
