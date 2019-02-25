import * as actionTypes from '../actions';
import { getSelfHref } from '../helpers/utilities';
import history from '../history';

export default () => next => action => {
    const result = next(action);

    switch (action.type) {
        case actionTypes.RECEIVE_NEW_CARTON_TYPE:
        case actionTypes.sernosConfigActionTypes.RECEIVE_NEW_SERNOS_CONFIG:
        case actionTypes.productRangeActionTypes.RECEIVE_NEW_PRODUCT_RANGE:
            history.push(getSelfHref(action.payload.data));
            break;
        default:
    }

    return result;
};
