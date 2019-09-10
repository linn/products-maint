import { ReportActions } from '@linn-it/linn-form-components-library';
import { ordersByNominalReportActionTypes as actionTypes } from './index';
import * as reportTypes from '../reportTypes';
import config from '../config';

export default new ReportActions(
    reportTypes.ordersByNominalReport.actionType,
    reportTypes.ordersByNominalReport.uri,
    actionTypes,
    config.appRoot
);
