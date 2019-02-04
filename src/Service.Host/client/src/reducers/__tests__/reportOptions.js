import deepFreeze from 'deep-freeze';
import reportOptions from '../reducerFactories/reportOptions';

describe('standard report options reducer factory', () => {
    const requestType = 'REQUEST';
    const generatedReducer = reportOptions(requestType);

    test('when requesting report', () => {
        const state = {};

        const action = {
            type: requestType,
            payload: {
                options: { option1: '1', option2: '2' }
            }
        };

        const expected = { option1: '1', option2: '2' };

        deepFreeze(state);

        expect(generatedReducer(state, action)).toEqual(expected);
    });
});
