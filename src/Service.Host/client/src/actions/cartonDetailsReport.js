import { cartonDetailsReportActionTypes as actionTypes } from './index';
import ReportActions from './ReportActions';
import * as reportTypes from '../reportTypes';

export default new ReportActions(
    reportTypes.cartonDetailsReport.actionType,
    reportTypes.cartonDetailsReport.uri,
    actionTypes
);
