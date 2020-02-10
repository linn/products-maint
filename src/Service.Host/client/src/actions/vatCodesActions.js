import { FetchApiActions } from '@linn-it/linn-form-components-library';
import { vatCodesActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new FetchApiActions(
    itemTypes.vatCodes.item,
    itemTypes.vatCodes.actionType,
    itemTypes.vatCodes.uri,
    actionTypes,
    config.appRoot
);
