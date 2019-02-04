export default function reportOptions(requestActionType, defaultState = {}) {
    return function options(state = defaultState, action) {
        switch (action.type) {
            case requestActionType:
                return {
                    ...action.payload.options
                };
            default:
                return state;
        }
    };
}
