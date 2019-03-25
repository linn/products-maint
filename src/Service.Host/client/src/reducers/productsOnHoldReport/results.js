import * as actionTypes from '../../actions';

export default function results(state = { loading: false, data: null }, action) {
    switch (action.type) {
        case actionTypes.REQUEST_PRODUCTS_ON_HOLD_REPORT:
            return {
                ...state,
                loading: true,
                data: null
            };

        case actionTypes.RECEIVE_PRODUCTS_ON_HOLD_REPORT:
            return {
                ...state,
                loading: false,
                data: action.payload.data.reportResults[0]
            };

        default:
            return state;
    }
}
