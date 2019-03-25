import * as actionTypes from '../../actions';

export default function results(state = { loading: false, data: null }, action) {
    switch (action.type) {
        case actionTypes.REQUEST_STOCK_TRIGGER_LEVELS_REPORT:
            return {
                ...state,
                loading: true,
                data: null
            };
        case actionTypes.RECEIVE_STOCK_TRIGGER_LEVELS_REPORT:
            return {
                ...state,
                loading: false,
                data: action.payload.data.reportResults[0]
            };

        default:
            return state;
    }
}
