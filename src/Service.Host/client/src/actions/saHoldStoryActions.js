import { saHoldStoryActionTypes as actionTypes } from './index';
import UpdateApiActions from './UpdateApiActions';
import * as itemTypes from '../itemTypes';

export default new UpdateApiActions(
    itemTypes.saHoldStory.actionType,
    itemTypes.saHoldStory.uri,
    actionTypes
);
