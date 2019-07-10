import { ReportActions } from '@linn-it/linn-form-components-library';
import { salesArticlesByTariffReportActionTypes as actionTypes } from './index';
import * as reportTypes from '../reportTypes';
import config from '../config';

export default new ReportActions(
    reportTypes.salesArticlesByTariffReport.actionType,
    reportTypes.salesArticlesByTariffReport.uri,
    actionTypes,
    config.appRoot
);
