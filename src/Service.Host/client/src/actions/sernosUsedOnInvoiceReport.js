import { ReportActions } from '@linn-it/linn-form-components-library';
import { sernosUsedOnInvoiceReportActionTypes as actionTypes } from './index';
import * as reportTypes from '../reportTypes';
import config from '../config';

export default new ReportActions(
    reportTypes.sernosUsedOnInvoiceReport.item,
    reportTypes.sernosUsedOnInvoiceReport.actionType,
    reportTypes.sernosUsedOnInvoiceReport.uri,
    actionTypes,
    config.appRoot
);
