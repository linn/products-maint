import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { vatCodeActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new UpdateApiActions(
    itemTypes.vatCode.item,
    itemTypes.vatCode.actionType,
    itemTypes.vatCode.uri,
    actionTypes,
    config.appRoot
);
