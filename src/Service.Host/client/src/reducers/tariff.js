import * as actionTypes from '../actions';

const defaultState = {
    loading: false,
    item: null
}

const tariff = (state = defaultState, action) => {
    switch (action.type) {
    case actionTypes.REQUEST_TARIFF:
        return {
            loading: true,
            item: null
        }

    case actionTypes.RECEIVE_TARIFF:
        return {
            ...state,
            loading: false,
            item: action.payload.data
        }

    default:
        return state;
    }
}

export default tariff;