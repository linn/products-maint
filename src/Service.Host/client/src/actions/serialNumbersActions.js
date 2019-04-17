import { serialNumbersActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(
    itemTypes.serialNumbers.actionType,
    itemTypes.serialNumbers.uri,
    actionTypes
);
