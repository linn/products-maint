export default function (itemRoot, actionTypes, defaultState = { loading: false, item: null, editStatus: 'view' })
{
    return (state = defaultState, action) => {
        switch (action.type) {
        case actionTypes[`REQUEST_ADD_${itemRoot}`]:
            return {
                ...state,
                loading: true,
                editStatus: 'create'
            }
        case actionTypes[`REQUEST_${itemRoot}`]:
            return {
                ...state,
                loading: true,
                editStatus: 'view'
            }

        case actionTypes[`REQUEST_UPDATE_${itemRoot}`]:
            return {
                ...state,
                editStatus: 'edit'
            }

        case actionTypes[`RESET_${itemRoot}`]:
            return {
                ...state,
                editStatus: 'view'
            }

        case actionTypes[`RECEIVE_${itemRoot}`]:
        case actionTypes[`RECEIVE_NEW_${itemRoot}`]:
            return {
                ...state,
                loading: false,
                item: action.payload.data,
                editStatus: 'view'
            }
        }

        return state;
    }
}
