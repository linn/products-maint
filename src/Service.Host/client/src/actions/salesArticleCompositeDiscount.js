import { salesArticleCompositeDiscountActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(
    itemTypes.salesArticleCompositeDiscount.actionType,
    itemTypes.salesArticleCompositeDiscount.uri,
    actionTypes
);
