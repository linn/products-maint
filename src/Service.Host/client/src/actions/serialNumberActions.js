import { serialNumberActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(
    itemTypes.serialNumber.actionType,
    itemTypes.serialNumber.uri,
    actionTypes
);
