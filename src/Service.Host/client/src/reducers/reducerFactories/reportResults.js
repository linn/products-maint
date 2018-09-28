export default function reportResults(requestActionType, receiveActionType, defaultState = { loading: false, data: null }) {
    return function results(state = defaultState, action) {
        switch (action.type) {
        case requestActionType:
            return {
                ...state,
                loading: true,
                data: null
            }

            case receiveActionType:
            return {
                ...state,
                loading: false,
                data: action.payload.data.reportResults[0]
            }

        default:
            return state;
        }
    }
}
