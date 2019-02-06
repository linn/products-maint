import reportResults from '../reducerFactories/reportResults';
import * as actionTypes from '../../actions';

export default reportResults(
    actionTypes.REQUEST_CARTON_DETAILS_REPORT,
    actionTypes.RECEIVE_CARTON_DETAILS_REPORT
);
