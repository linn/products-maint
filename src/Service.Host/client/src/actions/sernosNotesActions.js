import { sernosNotesActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(
    itemTypes.sernosNotes.actionType,
    itemTypes.sernosNotes.uri,
    actionTypes
);
