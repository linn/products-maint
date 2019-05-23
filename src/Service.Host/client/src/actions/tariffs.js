import { FetchApiActions } from '@linn-it/linn-form-components-library';
import { tariffsActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new FetchApiActions(
    itemTypes.tariffs.actionType,
    itemTypes.tariff.uri,
    actionTypes,
    config.appRoot
);
