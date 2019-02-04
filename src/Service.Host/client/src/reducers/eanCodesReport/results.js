import reportResults from '../reducerFactories/reportResults';
import * as actionTypes from '../../actions';

export default reportResults(
    actionTypes.REQUEST_EAN_CODE_REPORT,
    actionTypes.RECEIVE_EAN_CODE_REPORT
);
