import { ReportActions } from '@linn-it/linn-form-components-library';
import { saCoreTypeReportActionTypes as actionTypes } from './index';
import * as reportTypes from '../reportTypes';
import config from '../config';

export default new ReportActions(
    reportTypes.salesArticleCoreTypes.item,
    reportTypes.salesArticleCoreTypes.actionType,
    reportTypes.salesArticleCoreTypes.uri,
    actionTypes,
    config.appRoot
);
