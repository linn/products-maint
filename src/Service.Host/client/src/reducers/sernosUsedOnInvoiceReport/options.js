import { reportOptionsFactory } from '@linn-it/linn-form-components-library';
import { sernosUsedOnInvoiceReportActionTypes as actionTypes } from '../../actions';
import * as reportTypes from '../../reportTypes';

const defaultState = {};

export default reportOptionsFactory(
    reportTypes.sernosUsedOnInvoiceReport.actionType,
    actionTypes,
    defaultState
);
