﻿import { ReportActions } from '@linn-it/linn-form-components-library';
import { eanCodesReportTypes as actionTypes } from './index';
import * as reportTypes from '../reportTypes';
import config from '../config';

export default new ReportActions(
    reportTypes.eanCodesReport.actionType,
    reportTypes.eanCodesReport.uri,
    actionTypes,
    config.appRoot
);
