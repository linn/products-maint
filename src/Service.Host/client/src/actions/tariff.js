﻿import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { tariffActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new UpdateApiActions(
    itemTypes.tariff.item,
    itemTypes.tariff.actionType,
    itemTypes.tariff.uri,
    actionTypes,
    config.appRoot
);
