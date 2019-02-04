import reportResults from '../reducerFactories/reportResults';
import * as actionTypes from '../../actions';

export default reportResults(
    actionTypes.REQUEST_PRODUCT_RANGES_REPORT,
    actionTypes.RECEIVE_PRODUCT_RANGES_REPORT
);
