import { FetchApiActions } from '@linn-it/linn-form-components-library';
import { serialNumberTransactionCountsActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new FetchApiActions(
    itemTypes.serialNumberTransCounts.actionType,
    itemTypes.serialNumberTransCounts.uri,
    actionTypes,
    config.appRoot
);
