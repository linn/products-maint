import { vatCodeActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(
    itemTypes.vatCode.actionType,
    itemTypes.vatCode.uri,
    actionTypes
);
