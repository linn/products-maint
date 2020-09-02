import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { salesArticlesReallocateActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new UpdateApiActions(
    itemTypes.salesArticlesReallocate.item,
    itemTypes.salesArticlesReallocate.actionType,
    itemTypes.salesArticlesReallocate.uri,
    actionTypes,
    config.appRoot
);
