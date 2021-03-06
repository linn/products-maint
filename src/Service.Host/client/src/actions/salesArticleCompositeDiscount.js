import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { salesArticleCompositeDiscountActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new UpdateApiActions(
    itemTypes.salesArticleCompositeDiscount.item,
    itemTypes.salesArticleCompositeDiscount.actionType,
    itemTypes.salesArticleCompositeDiscount.uri,
    actionTypes,
    config.appRoot
);
