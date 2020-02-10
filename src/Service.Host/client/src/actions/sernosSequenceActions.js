import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { sernosSequenceActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new UpdateApiActions(
    itemTypes.sernosSequence.item,
    itemTypes.sernosSequence.actionType,
    itemTypes.sernosSequence.uri,
    actionTypes,
    config.appRoot
);
