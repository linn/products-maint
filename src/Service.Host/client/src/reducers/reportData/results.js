import reportResults from '../reducerFactories/reportResults';
import * as actionTypes from '../../actions';

export default reportResults(actionTypes.REQUEST_REPORT, actionTypes.RECEIVE_REPORT);
