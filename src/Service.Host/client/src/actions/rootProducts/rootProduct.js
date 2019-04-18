import { rootProductActionTypes as actionTypes } from '../index';
import UpdateApiActions from '../UpdateApiActions';
import * as itemTypes from '../../itemTypes';

export default new UpdateApiActions(
    itemTypes.rootProduct.actionType,
    itemTypes.rootProduct.uri,
    actionTypes
);
