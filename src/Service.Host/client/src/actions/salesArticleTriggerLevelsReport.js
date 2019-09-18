import { ReportActions } from '@linn-it/linn-form-components-library';
import { salesArticleTriggerLevelsReportActionTypes as actionTypes } from './index';
import * as reportTypes from '../reportTypes';
import config from '../config';

export default new ReportActions(
    reportTypes.salesArticleTriggerLevelsReport.actionType,
    reportTypes.salesArticleTriggerLevelsReport.uri,
    actionTypes,
    config.appRoot
);
