import reportResults from '../reducerFactories/reportResults';
import * as actionTypes from '../../actions';

export default reportResults(
    actionTypes.REQUEST_STOCK_TRIGGER_LEVELS_REPORT,
    actionTypes.RECEIVE_STOCK_TRIGGER_LEVELS_REPORT,
    actionTypes.RECEIVE_STOCK_TRIGGER_LEVELS_REPORT_BY_PART,
    actionTypes.RECEIVE_STOCK_TRIGGER_LEVELS_REPORT_BY_PART
    );
