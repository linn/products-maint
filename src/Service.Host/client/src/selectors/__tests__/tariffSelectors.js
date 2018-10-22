import { getTariffs, getTariffsLoading } from '../tariffSelectors';

describe('when getting tariffs', () => {
    test('should return items', () => {

        const state = {
            tariffs: {
                items: [{
                    tariffCode: '1'
                }]
            }
        }

        const expectedResult = [{ tariffCode: '1' }];

        expect(getTariffs(state)).toEqual(expectedResult);
    });
});

describe('when getting loading', () => {
    test('should return loading', () => {

        const state = {
            tariffs: {
                items: [],
                loading: true
            }
        }

        expect(getTariffsLoading(state)).toEqual(true);
    });
});