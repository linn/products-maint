import { salesArticlesActionTypes as actionTypes } from './index';
import FetchApiActions from './FetchApiActions';
import * as itemTypes from '../itemTypes';

export default new FetchApiActions(
    itemTypes.salesArticles.actionType,
    itemTypes.salesArticles.uri,
    actionTypes
);
