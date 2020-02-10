import { FetchApiActions } from '@linn-it/linn-form-components-library';
import { typesOfSaleActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new FetchApiActions(
    itemTypes.typesOfSale.item,
    itemTypes.typesOfSale.actionType,
    itemTypes.typesOfSale.uri,
    actionTypes,
    config.appRoot
);
