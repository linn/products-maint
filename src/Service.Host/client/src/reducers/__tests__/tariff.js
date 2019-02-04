import deepFreeze from 'deep-freeze';
import tariff from '../tariff';
import * as actionTypes from '../../actions';

describe('tariff reducer', () => {

    test('when requesting tariff', () => {
        const state = {
            loading: false
        };

        const action = {
            type: actionTypes.REQUEST_TARIFF,
            payload: {}
        };

        const expected = {
            loading: true,
            item: null
        };

        deepFreeze(state);

        expect(tariff(state, action)).toEqual(expected);
    });

    test('when receiving tariff', () => {
        const state = {
            loading: true,
            item: null
        };

        const action = {
            type: actionTypes.RECEIVE_TARIFF,
            payload: { data: { description: 'test tariff' } }
        };

        const expected = {
            loading: false,
            item: { description: 'test tariff' }
        };

        deepFreeze(state);

        expect(tariff(state, action)).toEqual(expected);
    });
});
