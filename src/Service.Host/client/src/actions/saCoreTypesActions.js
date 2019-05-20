import { FetchApiActions } from '@linn-it/linn-form-components-library';
import { saCoreTypesActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new FetchApiActions(
    itemTypes.saCoreTypes.actionType,
    itemTypes.saCoreTypes.uri,
    actionTypes,
    config.appRoot
);
