import { sernosConfigsActionTypes as actionTypes } from './index';
import FetchApiActions from './FetchApiActions';
import * as itemTypes from '../itemTypes';

export default new FetchApiActions(itemTypes.sernosConfigs.actionType, itemTypes.sernosConfigs.uri, actionTypes);
