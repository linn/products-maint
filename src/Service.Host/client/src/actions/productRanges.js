import { FetchApiActions } from '@linn-it/linn-form-components-library';
import { productRangesActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new FetchApiActions(
    itemTypes.productRanges.actionType,
    itemTypes.productRanges.uri,
    actionTypes,
    config.appRoot
);
