import deepFreeze from 'deep-freeze';
import salesProductsByProductRangeReport from '../salesProductsByProductRangeReport';
import { salesProductsByProductRangeReportActionTypes as actionTypes } from '../../actions';

describe('Sales Product By Range Report reducer', () => {
    test('when requesting report', () => {
        const state = {
            results: {
                loading: false,
                data: {}
            },
            options: {}
        };

        const action = {
            type: actionTypes.REQUEST_SALES_PRODUCTS_BY_RANGE,
            payload: {
                options: { productRangeId: 1, includePhasedOut: 'false' }
            }
        };

        const expected = {
            results: {
                loading: true,
                data: null
            },
            options: { productRangeId: 1, includePhasedOut: false }
        };

        deepFreeze(state);

        expect(salesProductsByProductRangeReport(state, action)).toEqual(expected);
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
            type: actionTypes.RECEIVE_SALES_PRODUCTS_BY_RANGE,
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

        expect(salesProductsByProductRangeReport(state, action)).toEqual(expected);
    });
});
