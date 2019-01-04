import { cartonTypeActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(itemTypes.cartonType.actionType, itemTypes.cartonType.uri, actionTypes);
