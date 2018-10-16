import * as actionTypes from '../../actions';

const defaultState = {
    loading: false,
    item: null,
    editStatus: 'view'
}

const cartonTypes = (state = defaultState, action) => {
    switch (action.type) {
        case actionTypes.REQUEST_ADD_CARTON_TYPE:
            return {
                ...state,
                loading: true,
                editStatus: 'create'
            }
        case actionTypes.REQUEST_CARTON_TYPE:
        return {
            ...state,
            loading: true,
            editStatus: 'view'
        }

        case actionTypes.REQUEST_UPDATE_CARTON_TYPE:
            return {
                ...state,
                editStatus: 'edit'
            }

        case actionTypes.RESET_CARTON_TYPE:
            return {
                ...state,
                editStatus: 'view'
            }

        case actionTypes.RECEIVE_CARTON_TYPE:
        case actionTypes.RECEIVE_NEW_CARTON_TYPE:
        return {
            ...state,
            loading: false,
            item: action.payload.data,
            editStatus: 'view'
        }
    }

    return state;
}

export default cartonTypes;