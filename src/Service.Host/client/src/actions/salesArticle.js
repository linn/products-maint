import { salesArticleActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(
    itemTypes.salesArticle.actionType,
    itemTypes.salesArticle.uri,
    actionTypes
);
