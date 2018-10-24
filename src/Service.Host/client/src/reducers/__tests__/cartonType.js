import cartonType from '../cartonType';
import deepFreeze from 'deep-freeze';
import * as actionTypes from '../../actions';

describe('carton type reducer', () => {

    test('when requesting carton type', () => {
        const state = {
            loading: false
        };

        const action = {
            type: actionTypes.REQUEST_CARTON_TYPE,
            payload: {}
        };

        const expected = {
            loading: true,
            editStatus: 'view'
        };

        deepFreeze(state);

        expect(cartonType(state, action)).toEqual(expected);
    });

    test('when resetting carton type', () => {
        const state = {
            loading: false, 
            item: { name: 'name'}
        };

        const action = {
            type: actionTypes.RESET_CARTON_TYPE,
            payload: {}
        };

        const expected = {
            loading: false,
            item: { name: 'name' },
            editStatus: 'view'
        };

        deepFreeze(state);

        expect(cartonType(state, action)).toEqual(expected);
    });

    test('when requesting update carton type', () => {
        const state = {
            loading: false
        };

        const action = {
            type: actionTypes.REQUEST_UPDATE_CARTON_TYPE,
            payload: {}
        };

        const expected = {
            loading: false,
            editStatus: 'edit'
        };

        deepFreeze(state);

        expect(cartonType(state, action)).toEqual(expected);
    });

    test('when requesting add carton type', () => {
        const state = {
            loading: false
        };

        const action = {
            type: actionTypes.REQUEST_ADD_CARTON_TYPE,
            payload: {}
        };

        const expected = {
            loading: true,
            editStatus: 'create'
        };

        deepFreeze(state);

        expect(cartonType(state, action)).toEqual(expected);
    });

    test('when receiving carton type', () => {
        const state = {
            loading: true,
            item: null
        };

        const action = {
            type: actionTypes.RECEIVE_CARTON_TYPE,
            payload: { data: { name: 'carton 1' } }
        };

        const expected = {
            loading: false,
            item: { name: 'carton 1' },
            editStatus: 'view'
        };

        deepFreeze(state);

        expect(cartonType(state, action)).toEqual(expected);
    });

    test('when receiving new carton type', () => {
        const state = {
            loading: true,
            item: null
        };

        const action = {
            type: actionTypes.RECEIVE_NEW_CARTON_TYPE,
            payload: { data: { name: 'carton 1' } }
        };

        const expected = {
            loading: false,
            item: { name: 'carton 1' },
            editStatus: 'view'
        };

        deepFreeze(state);

        expect(cartonType(state, action)).toEqual(expected);
    });
});