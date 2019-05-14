import { serialNumberTransactionActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(
    itemTypes.serialNumberTransaction.actionType,
    itemTypes.serialNumberTransaction.uri,
    actionTypes
);
