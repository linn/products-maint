import { reportOptionsFactory } from '@linn-it/linn-form-components-library';
import { saCoreTypeReportActionTypes as actionTypes } from '../../actions';
import * as reportTypes from '../../reportTypes';

const defaultState = {};

export default reportOptionsFactory(
    reportTypes.salesArticleCoreTypes.actionType,
    actionTypes,
    defaultState
);
