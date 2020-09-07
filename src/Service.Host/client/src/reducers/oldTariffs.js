import { collectionWithLinksStoreFactory } from '@linn-it/linn-form-components-library';
import { oldTariffsActionTypes as actionTypes } from '../actions';
import * as itemTypes from '../itemTypes';

const defaultState = {
    loading: false,
    items: [],
    searchItems: []
};

export default collectionWithLinksStoreFactory(
    itemTypes.oldTariffs.actionType,
    actionTypes,
    defaultState
);
