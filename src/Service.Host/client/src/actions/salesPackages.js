import { salesPackagesActionTypes as actionTypes } from './index';
import FetchApiActions from './FetchApiActions';
import * as itemTypes from '../itemTypes';

export default new FetchApiActions(
    itemTypes.salesPackages.actionType,
    itemTypes.salesPackages.uri,
    actionTypes
);
