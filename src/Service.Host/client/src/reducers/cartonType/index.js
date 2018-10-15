import * as actionTypes from '../../actions';

const defaultState = {
    loading: false,
    item: null
}

const cartonTypes = (state = defaultState, action) => {
    switch (action.type) {
        case actionTypes.REQUEST_ADD_CARTON_TYPE:
        case actionTypes.REQUEST_UPDATE_CARTON_TYPE:
        case actionTypes.REQUEST_CARTON_TYPE:
        return {
            ...state,
            loading: true
        }

        case actionTypes.RECEIVE_CARTON_TYPE:
        case actionTypes.RECEIVE_NEW_CARTON_TYPE:
        return {
            ...state,
            loading: false,
            item: action.payload.data
        }
    }

    return state;
}

export default cartonTypes;