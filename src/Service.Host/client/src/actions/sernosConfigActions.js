import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { sernosConfigActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new UpdateApiActions(
    itemTypes.sernosConfig.actionType,
    itemTypes.sernosConfig.uri,
    actionTypes,
    config.appRoot
);
