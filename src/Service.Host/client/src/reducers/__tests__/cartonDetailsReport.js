﻿import deepFreeze from 'deep-freeze';
import cartonDetailsReport from '../cartonDetailsReport';
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
            type: actionTypes.cartonDetailsReportActionTypes.REQUEST_CARTON_DETAILS,
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
            type: actionTypes.cartonDetailsReportActionTypes.RECEIVE_CARTON_DETAILS,
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
