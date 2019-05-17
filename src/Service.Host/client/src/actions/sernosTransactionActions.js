import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { sernosTransactionActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new UpdateApiActions(
    itemTypes.sernosTransaction.actionType,
    itemTypes.sernosTransaction.uri,
    actionTypes,
    config.appRoot
);
