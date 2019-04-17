import { sernosNoteActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(
    itemTypes.sernosNote.actionType,
    itemTypes.sernosNote.uri,
    actionTypes
);
