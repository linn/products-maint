import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { sernosNotesActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new UpdateApiActions(
    itemTypes.sernosNotes.actionType,
    itemTypes.sernosNotes.uri,
    actionTypes,
    config.appRoot
);
