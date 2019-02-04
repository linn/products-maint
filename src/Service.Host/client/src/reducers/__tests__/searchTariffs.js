import deepFreeze from 'deep-freeze';
import searchTariffs from '../searchTariffs';
import * as actionTypes from '../../actions';

describe('search tariffs reducer', () => {
    test('when requesting search tariffs', () => {
        const state = {
            loading: false
        };

        const action = {
            type: actionTypes.REQUEST_SEARCH_TARIFFS,
            payload: {}
        };

        const expected = {
            loading: true
        };

        deepFreeze(state);

        expect(searchTariffs(state, action)).toEqual(expected);
    });

    test('when setting tariff search term', () => {
        const state = {
            loading: false
        };

        const action = {
            type: actionTypes.SET_TARIFF_SEARCH_TERM,
            payload: 'whiskey'
        };

        const expected = {
            loading: false,
            searchTerm: 'whiskey'
        };

        deepFreeze(state);

        expect(searchTariffs(state, action)).toEqual(expected);
    });

    test('when receiving search tariffs', () => {
        const state = {
            loading: true,
            items: []
        };

        const action = {
            type: actionTypes.RECEIVE_SEARCH_TARIFFS,
            payload: { data: [{ description: 'test tariff' }] }
        };

        const expected = {
            loading: false,
            items: [{ description: 'test tariff' }]
        };

        deepFreeze(state);

        expect(searchTariffs(state, action)).toEqual(expected);
    });
});
