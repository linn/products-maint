import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { salesPackageActionTypes as actionTypes } from '../index';
import * as itemTypes from '../../itemTypes';
import config from '../../config';

export default new UpdateApiActions(
    itemTypes.salesPackage.actionType,
    itemTypes.salesPackage.uri,
    actionTypes,
    config.appRoot
);
