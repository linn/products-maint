import { productRangesActionTypes as actionTypes } from './index';
import FetchApiActions from './FetchApiActions';
import * as itemTypes from '../itemTypes';

export default new FetchApiActions(
    itemTypes.productRanges.actionType,
    itemTypes.productRanges.uri,
    actionTypes
);
