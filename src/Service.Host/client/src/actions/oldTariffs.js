import { FetchApiActions } from '@linn-it/linn-form-components-library';
import { oldTariffsActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new FetchApiActions(
    itemTypes.oldTariffs.item,
    itemTypes.oldTariffs.actionType,
    itemTypes.oldTariffs.uri,
    actionTypes,
    config.appRoot
);
