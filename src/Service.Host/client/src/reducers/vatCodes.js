import { collectionWithLinksStoreFactory } from '@linn-it/linn-form-components-library';
import { vatCodesActionTypes as actionTypes } from '../actions';
import * as itemTypes from '../itemTypes';

const defaultState = {
    loading: false,
    items: [],
    links: []
};

export default collectionWithLinksStoreFactory(
    itemTypes.vatCodes.actionType,
    actionTypes,
    defaultState
);
