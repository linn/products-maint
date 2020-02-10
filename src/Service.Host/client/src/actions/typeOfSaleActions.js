import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { typeOfSaleActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new UpdateApiActions(
    itemTypes.typeOfSale.item,
    itemTypes.typeOfSale.actionType,
    itemTypes.typeOfSale.uri,
    actionTypes,
    config.appRoot
);
