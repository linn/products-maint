import * as actionTypes from '../actions';

const defaultState = {
    loading: false,
    items: null
}

const tariffs = (state = defaultState, action) => {
    switch (action.type) {
        case actionTypes.REQUEST_TARIFFS:
        return {
            ...state,
            loading: true
        }

        case actionTypes.RECEIVE_TARIFFS:
        return {
            ...state,
            loading: false,
            items: action.payload.data
        }

    default:
        return state;
    }
}

export default tariffs;