import { getCartonType, getCartonLoading, getCartonEditStatus } from '../cartonTypeSelectors';

describe('when getting carton type', () => {
    test('should return carton', () => {
        const state = {
            cartonType: {
                item: { name: 'name' }
            }
        };

        const expectedResult = { name: 'name' };

        expect(getCartonType(state)).toEqual(expectedResult);
    });
});

describe('when getting no carton type', () => {
    test('should return null', () => {
        const state = {
            cartonType: {
                item: null
            }
        };

        expect(getCartonType(state)).toEqual(null);
    });
});

describe('when getting loading', () => {
    test('should return true', () => {
        const state = {
            cartonType: {
                item: null,
                loading: true
            }
        };

        expect(getCartonLoading(state)).toEqual(true);
    });
});

describe('when getting edit status', () => {
    test('should return status', () => {
        const state = {
            cartonType: {
                item: { name: 'name' },
                loading: false,
                editStatus: 'create'
            }
        };

        const expectedResult = 'create';

        expect(getCartonEditStatus(state)).toEqual(expectedResult);
    });
});

describe('when getting no edit status', () => {
    test('should return view', () => {
        const state = {
            cartonType: {
                item: { name: 'name' },
                loading: false
            }
        };

        const expectedResult = 'view';

        expect(getCartonEditStatus(state)).toEqual(expectedResult);
    });
});
