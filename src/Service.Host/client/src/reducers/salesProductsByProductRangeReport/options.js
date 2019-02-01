import * as actionTypes from '../../actions';

const defaultState = { includePhasedOut: false };

export default function options(state = defaultState, action) {
    switch (action.type) {
        case actionTypes.REQUEST_SALES_PRODUCTS_BY_RANGE_REPORT:
            return {
                ...state,
                includePhasedOut: action.payload.options.includePhasedOut === 'true',
                productRangeId: action.payload.options.productRangeId
            };
        default:
            return state;
    }
}
