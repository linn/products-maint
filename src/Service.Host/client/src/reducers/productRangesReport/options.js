import * as actionTypes from '../../actions';

const defaultState = { includePhasedOut: false };

export default function options(state = defaultState, action) {
    switch (action.type) {
        case actionTypes.REQUEST_PRODUCT_RANGES_REPORT:
            return {
                ...state,
                includePhasedOut: action.payload.options.includePhasedOut === 'true'
            };
        default:
            return state;
    }
}
