import { sernosSequenceActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(
    itemTypes.sernosSequence.actionType,
    itemTypes.sernosSequence.uri,
    actionTypes
);
