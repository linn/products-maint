import { eanCodesReportTypes as actionTypes } from './index';
import ReportActions from './ReportActions';
import * as reportTypes from '../reportTypes';

export default new ReportActions(
    reportTypes.eanCodesReport.actionType,
    reportTypes.eanCodesReport.uri,
    actionTypes
);
