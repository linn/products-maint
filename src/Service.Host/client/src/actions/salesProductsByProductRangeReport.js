import { salesProductsByProductRangeReportActionTypes as actionTypes } from './index';
import ReportActions from './ReportActions';
import * as reportTypes from '../reportTypes';

export default new ReportActions(
    reportTypes.salesProductsByProductRangeReport.actionType,
    reportTypes.salesProductsByProductRangeReport.uri,
    actionTypes
);
