import * as actionTypes from '../../actions';

const defaultState = null;

const fetchError = (state, action) => {
    switch (action.type) {
        case actionTypes.FETCH_ERROR:
            return action.payload.error
                ? {
                      status: action.payload.error.status,
                      statusText: action.payload.error.statusText,
                      errors: action.payload.error.details.errors
                  }
                : { statusText: action.payload };
        default:
            return defaultState;
    }
};

export default fetchError;
