import { sernosSequencesActionTypes as actionTypes } from './index';
import FetchApiActions from './FetchApiActions';
import * as itemTypes from '../itemTypes';

export default new FetchApiActions(
    itemTypes.sernosSequences.actionType,
    itemTypes.sernosSequences.uri,
    actionTypes
);
