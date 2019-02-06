import { tariffActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(itemTypes.tariff.actionType, itemTypes.tariff.uri, actionTypes);
