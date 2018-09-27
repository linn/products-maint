import reportResults from '../reducerFactories/reportResults';
import deepFreeze from 'deep-freeze';

describe('standard report reducer factory', () => {
    const
        defaultState = { loading: false, data: null },
        requestType = 'REQUEST',
        receiveType = 'RECEIVE',
        generatedReducer = reportResults(requestType, receiveType, defaultState);

    test('when requesting report', () => {
        const state = {
            loading: false,
            data: {}
        };

        const action = {
            type: requestType,
            payload: {}
        };

        const expected = {
            loading: true,
            data: null
        };

        deepFreeze(state);

        expect(generatedReducer(state, action)).toEqual(expected);
    });


    test('when receiving report', () => {
        const state = {
            loading: true,
            data: null
        };

        const action = {
            type: receiveType,
            payload: {
                data: { reportResults: [{ result: 1 }] }
            }
        };

        const expected = {
            loading: false,
            data: { result: 1 }
        };

        deepFreeze(state);

        expect(generatedReducer(state, action)).toEqual(expected);
    });
});