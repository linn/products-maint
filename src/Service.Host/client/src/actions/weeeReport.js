import { ReportActions } from '@linn-it/linn-form-components-library';
import { weeeReportActionTypes as actionTypes } from './index';
import * as reportTypes from '../reportTypes';
import config from '../config';

export default new ReportActions(
    reportTypes.weeeReport.item,
    reportTypes.weeeReport.actionType,
    reportTypes.weeeReport.uri,
    actionTypes,
    config.appRoot
);
