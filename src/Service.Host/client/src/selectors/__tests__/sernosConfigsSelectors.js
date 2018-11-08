import sernosConfigsSelectors from '../sernosConfigsSelectors';

describe('when getting items', () => {
    test('should return sernos configs', () => {

        const state = {
            sernosConfigs: {
                items: [{ name: 'name' }]
            }
        };

        const expectedResult = [{ name: 'name' }];

        expect(sernosConfigsSelectors.getItems(state)).toEqual(expectedResult);
    });
});

describe('when getting nothing', () => {
    test('should return empty', () => {

        const state = {
            sernosConfigs: {
                items: null
            }
        };

        expect(sernosConfigsSelectors.getItems(state)).toEqual([]);
    });
});

describe('when getting loading', () => {
    test('should return true', () => {

        const state = {
            sernosConfigs: {
                items: null,
                loading: true
            }
        };

        expect(sernosConfigsSelectors.getLoading(state)).toEqual(true);
    });
});

describe('when getting item by id', () => {
    test('should return item', () => {

        const state = {
            sernosConfigs: {
                items: [{ 'name': '1' }, { 'name': '2' }],
                loading: false
            }
        };

        const expectedResult = { name: '1' };

        expect(sernosConfigsSelectors.getItem(state, '1')).toEqual(expectedResult);
    });
});

describe('when getting item by href', () => {
    test('should return item', () => {

        const state = {
            sernosConfigs: {
                items: [{ name: '1', href : '/1' }, { name: '2', href: '/2' }],
                loading: false
            }
        };

        const expectedResult = { name: '1', href: '/1' };

        expect(sernosConfigsSelectors.getItemByHref(state, '/1')).toEqual(expectedResult);
    });
});