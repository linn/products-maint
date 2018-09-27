import eanCodesReport from '../eanCodesReport';
import deepFreeze from 'deep-freeze';
import * as actionTypes from '../../actions';

describe('ean Codes Report reducer', () => {

    test('when requesting report', () => {
        const state = {
            results: {
                loading: false,
                data: {}
            },
            options: {
            }
        };

        const action = {
            type: actionTypes.REQUEST_EAN_CODE_REPORT,
            payload: {
                options: { cartonisedOnly: 'true', includePhasedOut: 'false' }
            }
        };

        const expected = {
            results: {
                loading: true,
                data: null
            },
            options: { cartonisedOnly: true, includePhasedOut: false }
        };

        deepFreeze(state);

        expect(eanCodesReport(state, action)).toEqual(expected);
    });


    test('when receiving report', () => {
        const state = {
            results: {
                loading: true,
                data: null
            },
            options: {
            }
        };

        const action = {
            type: actionTypes.RECEIVE_EAN_CODE_REPORT,
            payload: {
                data: { reportResults: [{ result: 1 }] },
                options: { cartonisedOnly: 'true', includePhasedOut: 'false' }
            }
        };

        const expected = {
            results: {
                loading: false,
                data: { result: 1 }
            },
            options: {}
        };

        deepFreeze(state);

        expect(eanCodesReport(state, action)).toEqual(expected);
    });
});