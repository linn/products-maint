import { eanCodesReportTypes as actionTypes } from '../../actions';

const defaultState = { includePhasedOut: false, cartonisedOnly: true };

export default function options(state = defaultState, action) {
    switch (action.type) {
        case actionTypes.REQUEST_EAN_CODE_REPORT:
            return {
                ...state,
                includePhasedOut: action.payload.options.includePhasedOut === 'true',
                cartonisedOnly: action.payload.options.cartonisedOnly === 'true'
            };
        default:
            return state;
    }
}
