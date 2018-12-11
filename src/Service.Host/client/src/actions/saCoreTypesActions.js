import { saCoreTypesActionTypes as actionTypes } from './index';
import FetchApiActions from './FetchApiActions';
import * as itemTypes from '../itemTypes';

export default new FetchApiActions(itemTypes.saCoreTypes.actionType, itemTypes.saCoreTypes.uri, actionTypes);


