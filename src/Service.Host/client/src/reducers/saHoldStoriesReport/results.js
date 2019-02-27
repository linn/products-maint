import reportResults from '../reducerFactories/reportResults';
import * as actionTypes from '../../actions';

export default reportResults(
    actionTypes.REQUEST_SA_HOLD_STORIES_REPORT,
    actionTypes.RECEIVE_SA_HOLD_STORIES_REPORT
);
