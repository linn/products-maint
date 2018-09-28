import cartonDetailsReport from '../cartonDetailsReport';
import deepFreeze from 'deep-freeze';
import * as actionTypes from '../../actions';

describe('carton details report reducer', () => {

    test('when requesting report', () => {
        const state = {
            results: {
                loading: false,
                data: {}
            }
        };

        const action = {
            type: actionTypes.REQUEST_CARTON_DETAILS_REPORT,
            payload: {}
        };

        const expected = {
            results: {
                loading: true,
                data: null
            }
        };

        deepFreeze(state);

        expect(cartonDetailsReport(state, action)).toEqual(expected);
    });


    test('when receiving report', () => {
        const state = {
            results: {
                loading: true,
                data: null
            }
        };

        const action = {
            type: actionTypes.RECEIVE_CARTON_DETAILS_REPORT,
            payload: {
                data: { reportResults: [{ result: 1 }] }
            }
        };

        const expected = {
            results: {
                loading: false,
                data: { result: 1 }
            }
        };

        deepFreeze(state);

        expect(cartonDetailsReport(state, action)).toEqual(expected);
    });
});