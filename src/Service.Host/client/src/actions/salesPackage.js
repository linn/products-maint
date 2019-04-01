import { salesPackageActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(
    itemTypes.salesPackage.actionType,
    itemTypes.salesPackage.uri,
    actionTypes
);
