import reportResults from '../reducerFactories/reportResults';
import * as actionTypes from '../../actions';

export default reportResults(
    actionTypes.REQUEST_PRODUCTS_ON_HOLD_REPORT,
    actionTypes.RECEIVE_PRODUCTS_ON_HOLD_REPORT
);
