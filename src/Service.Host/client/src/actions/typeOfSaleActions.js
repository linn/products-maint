import { typeOfSaleActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(itemTypes.typeOfSale.actionType, itemTypes.typeOfSale.uri, actionTypes);
