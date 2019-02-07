import { tariffsActionTypes as actionTypes } from './index';
import FetchApiActions from './FetchApiActions';
import * as itemTypes from '../itemTypes';

export default new FetchApiActions(itemTypes.tariffs.actionType, itemTypes.tariff.uri, actionTypes);
