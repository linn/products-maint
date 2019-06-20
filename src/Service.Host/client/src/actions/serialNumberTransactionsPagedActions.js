import { FetchApiActions } from '@linn-it/linn-form-components-library';
import { serialNumberTransactionsPagedActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new FetchApiActions(
    itemTypes.serialNumberTransactionsPaged.actionType,
    itemTypes.serialNumberTransactionsPaged.uri,
    actionTypes,
    config.appRoot
);
