import { sernosTransactionsActionTypes as actionTypes } from './index';
import FetchApiActions from './FetchApiActions';
import * as itemTypes from '../itemTypes';

export default new FetchApiActions(
    itemTypes.sernosTransactions.actionType,
    itemTypes.sernosTransactions.uri,
    actionTypes
);
