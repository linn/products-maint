import { FetchApiActions } from '@linn-it/linn-form-components-library';
import { salesPackagesActionTypes as actionTypes } from '../index';
import * as itemTypes from '../../itemTypes';
import config from '../../config';

export default new FetchApiActions(
    itemTypes.salesPackages.actionType,
    itemTypes.salesPackages.uri,
    actionTypes,
    config.appRoot
);
