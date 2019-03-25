import { productRangesReportActionTypes as actionTypes } from './index';
import ReportActions from './ReportActions';
import * as reportTypes from '../reportTypes';

export default new ReportActions(
    reportTypes.productRangesReport.actionType,
    reportTypes.productRangesReport.uri,
    actionTypes
);
