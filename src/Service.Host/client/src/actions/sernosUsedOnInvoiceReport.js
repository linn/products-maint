import { sernosUsedOnInvoiceReportActionTypes as actionTypes } from './index';
import ReportActions from './ReportActions';
import * as reportTypes from '../reportTypes';

export default new ReportActions(
    reportTypes.sernosUsedOnInvoiceReport.actionType,
    reportTypes.sernosUsedOnInvoiceReport.uri,
    actionTypes
);
