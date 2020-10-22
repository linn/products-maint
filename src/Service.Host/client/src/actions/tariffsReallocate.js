import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { tariffsReallocateActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new UpdateApiActions(
    itemTypes.TariffsReallocate.item,
    itemTypes.TariffsReallocate.actionType,
    itemTypes.TariffsReallocate.uri,
    actionTypes,
    config.appRoot
);