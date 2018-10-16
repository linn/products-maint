import * as actionTypes from '../../actions';

const defaultState = null;

const fetchError = (state = defaultState, action) => {
    switch (action.type) {
        case actionTypes.REQUEST_ADD_CARTON_TYPE:
        case actionTypes.REQUEST_UPDATE_CARTON_TYPE:
        case actionTypes.REQUEST_CARTON_TYPE:
        case actionTypes.RESET_CARTON_TYPE:
            return defaultState;

        case actionTypes.FETCH_ERROR:
            return action.payload.error ?
                {
                    status: action.payload.error.status,
                    statusText: action.payload.error.statusText,
                    errors: action.payload.error.details.errors
                } :
                { statusText: action.payload }
    }

    return state;
}

export default fetchError;