export default function (itemRoot, actionTypes, defaultState = { loading: false, items: [] })
{
    return (state = defaultState, action) => {
        switch (action.type) {
        case actionTypes[`REQUEST_${itemRoot}`]:
            return {
                ...state,
                loading: true
            }
        case actionTypes[`RECEIVE_${itemRoot}`]:
            return {
                ...state,
                loading: false,
                items: action.payload.data
            }
        }

        return state;
    }
}
