import * as actionTypes from '../actions';
import { getSelfHref } from '../helpers/utilities';
import history from '../history';

export default () => next => action => {
    const result = next(action);

    switch (action.type) {
        case actionTypes.RECEIVE_NEW_CARTON_TYPE:
            history.push(getSelfHref(action.payload.data));
            break;
    }

    return result;
}