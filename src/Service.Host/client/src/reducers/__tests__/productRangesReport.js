import productRangesReport from '../productRangesReport';
import deepFreeze from 'deep-freeze';
import * as actionTypes from '../../actions';

describe('Product Ranges Report reducer', () => {

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
            type: actionTypes.REQUEST_PRODUCT_RANGES_REPORT,
            payload: {
                options: { includePhasedOut: 'false' }
            }
        };

        const expected = {
            results: {
                loading: true,
                data: null
            },
            options: { includePhasedOut: false }
        };

        deepFreeze(state);

        expect(productRangesReport(state, action)).toEqual(expected);
    });


    test('when receiving report', () => {
        const state = {
            results: {
                loading: true,
                data: null
            },
            options: {}
        };

        const action = {
            type: actionTypes.RECEIVE_PRODUCT_RANGES_REPORT,
            payload: {
                data: { reportResults: [{ result: 1 }] },
                options: { includePhasedOut: 'false' }
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

        expect(productRangesReport(state, action)).toEqual(expected);
    });
});