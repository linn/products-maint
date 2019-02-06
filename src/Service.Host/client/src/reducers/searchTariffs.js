import * as actionTypes from '../actions';

const defaultState = {
    loading: false,
    items: [],
    searchTerm: ''
};

const searchTariffs = (state = defaultState, action) => {
    switch (action.type) {
        case actionTypes.REQUEST_SEARCH_TARIFFS:
            return {
                ...state,
                loading: true
            };

        case actionTypes.RECEIVE_SEARCH_TARIFFS:
            return {
                ...state,
                loading: false,
                items: action.payload.data
            };

        case actionTypes.SET_TARIFF_SEARCH_TERM:
            return {
                ...state,
                searchTerm: action.payload
            };

        default:
            return state;
    }
};

export default searchTariffs;
