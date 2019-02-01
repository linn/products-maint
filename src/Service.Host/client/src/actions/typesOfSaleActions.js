import { typesOfSaleActionTypes as actionTypes } from './index';
import FetchApiActions from './FetchApiActions';
import * as itemTypes from '../itemTypes';

export default new FetchApiActions(
    itemTypes.typesOfSale.actionType,
    itemTypes.typesOfSale.uri,
    actionTypes
);
