import { serialNumberTransactionsActionTypes as actionTypes } from './index';
import FetchApiActions from './FetchApiActions';
import * as itemTypes from '../itemTypes';

export default new FetchApiActions(
    itemTypes.serialNumberTransactions.actionType,
    itemTypes.serialNumberTransactions.uri,
    actionTypes
);
