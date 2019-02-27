import { vatCodesActionTypes as actionTypes } from './index';
import FetchApiActions from './FetchApiActions';
import * as itemTypes from '../itemTypes';

export default new FetchApiActions(
    itemTypes.vatCodes.actionType,
    itemTypes.vatCodes.uri,
    actionTypes
);
