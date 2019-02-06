import { saCoreTypeActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(
    itemTypes.saCoreType.actionType,
    itemTypes.saCoreType.uri,
    actionTypes
);
