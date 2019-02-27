import * as actionTypes from '../../actions';

const defaultState = {};

export default function options(state = defaultState, action) {
    switch (action.type) {
        case actionTypes.REQUEST_REPORT:
            return {
                ...state,
                ...action.payload.options
            };
        default:
            return state;
    }
}
