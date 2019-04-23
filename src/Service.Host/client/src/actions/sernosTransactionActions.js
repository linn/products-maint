import { sernosTransactionActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(
    itemTypes.sernosTransaction.actionType,
    itemTypes.sernosTransaction.uri,
    actionTypes
);
