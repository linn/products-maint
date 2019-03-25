import deepFreeze from 'deep-freeze';
import fetchError from '../fetchError';
import * as actionTypes from '../../actions';
import cartonTypeActions from '../../actions/cartonTypeActions';

describe('fetch error reducer', () => {
    test('when full error received', () => {
        const state = null;

        const action = {
            type: actionTypes.FETCH_ERROR,
            payload: {
                error: {
                    status: 400,
                    statusText: '400 Bad Request',
                    details: { errors: ['Error 1', 'Error 2'] }
                }
            }
        };

        const expected = {
            status: 400,
            statusText: '400 Bad Request',
            errors: ['Error 1', 'Error 2']
        };

        expect(fetchError(state, action)).toEqual(expected);
    });

    test('when request add received', () => {
        const state = {
            status: 400,
            statusText: '400 Bad Request',
            errors: ['Error 1', 'Error 2']
        };

        const action = {
            type: cartonTypeActions.REQUEST_ADD_CARTON_TYPE,
            payload: {}
        };

        deepFreeze(state);

        const expected = null;

        expect(fetchError(state, action)).toEqual(expected);
    });

    test('when request update received', () => {
        const state = {
            status: 400,
            statusText: '400 Bad Request',
            errors: ['Error 1', 'Error 2']
        };

        const action = {
            type: cartonTypeActions.REQUEST_UPDATE_CARTON_TYPE,
            payload: {}
        };

        deepFreeze(state);

        const expected = null;

        expect(fetchError(state, action)).toEqual(expected);
    });

    test('when request received', () => {
        const state = {
            status: 400,
            statusText: '400 Bad Request',
            errors: ['Error 1', 'Error 2']
        };

        const action = {
            type: cartonTypeActions.REQUEST_CARTON_TYPE,
            payload: {}
        };

        deepFreeze(state);

        const expected = null;

        expect(fetchError(state, action)).toEqual(expected);
    });

    test('when partial error received', () => {
        const state = null;

        const action = {
            type: actionTypes.FETCH_ERROR,
            payload: 'Network failure'
        };

        const expected = {
            statusText: 'Network failure'
        };

        expect(fetchError(state, action)).toEqual(expected);
    });
});
