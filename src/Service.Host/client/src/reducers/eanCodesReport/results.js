import * as actionTypes from '../../actions';

const defaultState = { loading : false, data: null }

export default function results(state = defaultState, action) {
    switch (action.type) {
    case actionTypes.REQUEST_EAN_CODE_REPORT:
        return {
            ...state,
            loading: true,
            data: null
        }

        case actionTypes.RECEIVE_EAN_CODE_REPORT:
        return {
            ...state,
            loading: false,
            data: action.payload.data.reportResults[0]
        }

    default:
        return state;
    }}
