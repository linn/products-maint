import reportResults from '../reducerFactories/reportResults';
import * as actionTypes from '../../actions';

export default reportResults(
    actionTypes.REQUEST_SALES_PRODUCTS_BY_RANGE_REPORT,
    actionTypes.RECEIVE_SALES_PRODUCTS_BY_RANGE_REPORT
);
