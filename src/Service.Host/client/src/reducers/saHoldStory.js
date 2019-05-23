import { itemStoreFactory } from '@linn-it/linn-form-components-library';
import { saHoldStoryActionTypes as actionTypes } from '../actions';
import * as itemTypes from '../itemTypes';

const defaultState = {
    loading: false,
    item: null
};

export default itemStoreFactory(itemTypes.saHoldStory.actionType, actionTypes, defaultState);
