import { ReportActions } from '@linn-it/linn-form-components-library';
import { productRangesReportActionTypes as actionTypes } from './index';
import * as reportTypes from '../reportTypes';
import config from '../config';

export default new ReportActions(
    reportTypes.productRangesReport.item,
    reportTypes.productRangesReport.actionType,
    reportTypes.productRangesReport.uri,
    actionTypes,
    config.appRoot
);
