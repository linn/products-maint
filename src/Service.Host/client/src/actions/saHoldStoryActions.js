import { UpdateApiActions } from '@linn-it/linn-form-components-library';
import { saHoldStoryActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new UpdateApiActions(
    itemTypes.saHoldStory.item,
    itemTypes.saHoldStory.actionType,
    itemTypes.saHoldStory.uri,
    actionTypes,
    config.appRoot
);
