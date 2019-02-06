import sernosConfigSelectors from '../sernosConfigSelectors';

describe('when getting', () => {
    test('should return sernos config', () => {
        const state = {
            sernosConfig: {
                item: { name: 'name' }
            }
        };

        const expectedResult = { name: 'name' };

        expect(sernosConfigSelectors.getItem(state)).toEqual(expectedResult);
    });
});

describe('when getting nothing', () => {
    test('should return null', () => {
        const state = {
            sernosConfig: {
                item: null
            }
        };

        expect(sernosConfigSelectors.getItem(state)).toEqual(null);
    });
});

describe('when getting loading', () => {
    test('should return true', () => {
        const state = {
            sernosConfig: {
                item: null,
                loading: true
            }
        };

        expect(sernosConfigSelectors.getLoading(state)).toEqual(true);
    });
});

describe('when getting edit status', () => {
    test('should return status', () => {
        const state = {
            sernosConfig: {
                item: { name: 'name' },
                loading: false,
                editStatus: 'create'
            }
        };

        const expectedResult = 'create';

        expect(sernosConfigSelectors.getEditStatus(state)).toEqual(expectedResult);
    });
});

describe('when getting no edit status', () => {
    test('should return view', () => {
        const state = {
            sernosConfig: {
                item: { name: 'name' },
                loading: false
            }
        };

        const expectedResult = 'view';

        expect(sernosConfigSelectors.getEditStatus(state)).toEqual(expectedResult);
    });
});
