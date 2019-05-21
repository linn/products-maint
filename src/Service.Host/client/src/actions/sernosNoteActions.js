import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { sernosNoteActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new UpdateApiActions(
    itemTypes.sernosNote.actionType,
    itemTypes.sernosNote.uri,
    actionTypes,
    config.appRoot
);
