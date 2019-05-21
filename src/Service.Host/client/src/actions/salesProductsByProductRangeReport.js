import { ReportActions } from '@linn-it/linn-form-components-library';
import { salesProductsByProductRangeReportActionTypes as actionTypes } from './index';
import * as reportTypes from '../reportTypes';
import config from '../config';

export default new ReportActions(
    reportTypes.salesProductsByProductRangeReport.actionType,
    reportTypes.salesProductsByProductRangeReport.uri,
    actionTypes,
    config.appRoot
);
