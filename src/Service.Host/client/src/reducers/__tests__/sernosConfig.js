import deepFreeze from 'deep-freeze';
import sernosConfig from '../sernosConfig';
import { sernosConfigActionTypes as actionTypes } from '../../actions';

describe('sernos config reducer', () => {
    test('when requesting sernos config', () => {
        const state = {
            loading: false
        };

        const action = {
            type: actionTypes.REQUEST_SERNOS_CONFIG,
            payload: {}
        };

        const expected = {
            loading: true,
            editStatus: 'view'
        };

        deepFreeze(state);

        expect(sernosConfig(state, action)).toEqual(expected);
    });

    test('when resetting sernos config', () => {
        const state = {
            loading: false,
            item: { name: 'name'}
        };

        const action = {
            type: actionTypes.RESET_SERNOS_CONFIG,
            payload: {}
        };

        const expected = {
            loading: false,
            item: { name: 'name' },
            editStatus: 'view'
        };

        deepFreeze(state);

        expect(sernosConfig(state, action)).toEqual(expected);
    });

    test('when requesting update sernos config', () => {
        const state = {
            loading: false
        };

        const action = {
            type: actionTypes.REQUEST_UPDATE_SERNOS_CONFIG,
            payload: {}
        };

        const expected = {
            loading: false,
            editStatus: 'edit'
        };

        deepFreeze(state);

        expect(sernosConfig(state, action)).toEqual(expected);
    });

    test('when requesting add sernos config', () => {
        const state = {
            loading: false
        };

        const action = {
            type: actionTypes.REQUEST_ADD_SERNOS_CONFIG,
            payload: {}
        };

        const expected = {
            loading: true,
            editStatus: 'create'
        };

        deepFreeze(state);

        expect(sernosConfig(state, action)).toEqual(expected);
    });

    test('when receiving sernos config', () => {
        const state = {
            loading: true,
            item: null
        };

        const action = {
            type: actionTypes.RECEIVE_SERNOS_CONFIG,
            payload: { data: { name: '1' } }
        };

        const expected = {
            loading: false,
            item: { name: '1' },
            editStatus: 'view'
        };

        deepFreeze(state);

        expect(sernosConfig(state, action)).toEqual(expected);
    });

    test('when receiving new sernos config', () => {
        const state = {
            loading: true,
            item: null
        };

        const action = {
            type: actionTypes.RECEIVE_NEW_SERNOS_CONFIG,
            payload: { data: { name: '1' } }
        };

        const expected = {
            loading: false,
            item: { name: '1' },
            editStatus: 'view'
        };

        deepFreeze(state);

        expect(sernosConfig(state, action)).toEqual(expected);
    });
});
