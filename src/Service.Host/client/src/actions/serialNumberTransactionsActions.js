import { FetchApiActions } from '@linn-it/linn-form-components-library';
import { serialNumberTransactionsActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new FetchApiActions(
    itemTypes.serialNumberTransactions.item,
    itemTypes.serialNumberTransactions.actionType,
    itemTypes.serialNumberTransactions.uri,
    actionTypes,
    config.appRoot
);
