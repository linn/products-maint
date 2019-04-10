import { saCoreTypeReportActionTypes as actionTypes } from '../../actions';
import options from '../reducerFactories/reportOptionsFactory';
import * as reportTypes from '../../reportTypes';

const defaultState = {};

export default options(reportTypes.salesArticleCoreTypes.actionType, actionTypes, defaultState);
