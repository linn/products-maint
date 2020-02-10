import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { saCoreTypeActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new UpdateApiActions(
    itemTypes.saCoreType.item,
    itemTypes.saCoreType.actionType,
    itemTypes.saCoreType.uri,
    actionTypes,
    config.appRoot
);
