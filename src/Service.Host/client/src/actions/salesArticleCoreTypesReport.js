import { saCoreTypeReportActionTypes as actionTypes } from './index';
import ReportActions from './ReportActions';
import * as reportTypes from '../reportTypes';

export default new ReportActions(
    reportTypes.salesArticleCoreTypes.actionType,
    reportTypes.salesArticleCoreTypes.uri,
    actionTypes
);
