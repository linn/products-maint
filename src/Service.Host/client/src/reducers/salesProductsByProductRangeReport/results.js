import { salesProductsByProductRangeReportActionTypes as actionTypes } from '../../actions';
import results from '../reducerFactories/reportResultsFactory';
import * as reportTypes from '../../reportTypes';

const defaultState = { loading: false, data: null };

export default results(
    reportTypes.salesProductsByProductRangeReport.actionType,
    actionTypes,
    defaultState
);
