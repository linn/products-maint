import { FetchApiActions } from '@linn-it/linn-form-components-library';
import { sernosConfigsActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new FetchApiActions(
    itemTypes.sernosConfigs.actionType,
    itemTypes.sernosConfigs.uri,
    actionTypes,
    config.appRoot
);
