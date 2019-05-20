import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { productRangeActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new UpdateApiActions(
    itemTypes.productRange.actionType,
    itemTypes.productRange.uri,
    actionTypes,
    config.appRoot
);
