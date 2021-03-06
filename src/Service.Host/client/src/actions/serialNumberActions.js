import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { serialNumberActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new UpdateApiActions(
    itemTypes.serialNumber.item,
    itemTypes.serialNumber.actionType,
    itemTypes.serialNumber.uri,
    actionTypes,
    config.appRoot
);
