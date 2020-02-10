import { ReportActions } from '@linn-it/linn-form-components-library';
import { cartonDetailsReportActionTypes as actionTypes } from './index';
import * as reportTypes from '../reportTypes';
import config from '../config';

export default new ReportActions(
    reportTypes.cartonDetailsReport.item,
    reportTypes.cartonDetailsReport.actionType,
    reportTypes.cartonDetailsReport.uri,
    actionTypes,
    config.appRoot
);
