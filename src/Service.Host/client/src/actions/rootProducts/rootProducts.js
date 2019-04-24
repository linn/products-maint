import { rootProductsActionTypes as actionTypes } from '../index';
import FetchApiActions from '../FetchApiActions';
import * as itemTypes from '../../itemTypes';

export default new FetchApiActions(
    itemTypes.rootProducts.actionType,
    itemTypes.rootProducts.uri,
    actionTypes
);
