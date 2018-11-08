import { sernosConfigActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(itemTypes.sernosConfig.actionType, itemTypes.sernosConfig.uri, actionTypes);
