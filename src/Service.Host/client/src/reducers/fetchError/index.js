import * as actionTypes from '../../actions';

const defaultState = null;

const fetchError = (state = defaultState, action) => {
    switch (action.type) {
        case actionTypes.REQUEST_ADD_CARTON_TYPE:
        case actionTypes.REQUEST_UPDATE_CARTON_TYPE:
        case actionTypes.REQUEST_CARTON_TYPE:
        case actionTypes.RESET_CARTON_TYPE:
        case actionTypes.sernosConfigActionTypes.REQUEST_ADD_SERNOS_CONFIG:
        case actionTypes.sernosConfigActionTypes.REQUEST_UPDATE_SERNOS_CONFIG:
        case actionTypes.sernosConfigActionTypes.REQUEST_SERNOS_CONFIG:
        case actionTypes.sernosConfigsActionTypes.REQUEST_SERNOS_CONFIGS:
        case actionTypes.sernosConfigActionTypes.RESET_SERNOS_CONFIG:
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

    return defaultState;
}

export default fetchError;