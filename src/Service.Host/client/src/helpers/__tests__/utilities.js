import { sortEntityList, sortList } from '../utilities';

describe('when sorting an entity list', () => {
    const entityList = [
        {
            name: 'zara',
            age: 44.1,
            created: '2000-06-05T15:00:10.0000000'
        },
        {
            name: 'alfie',
            age: 66,
            created: '2010-06-05T15:00:10.0000000'
        },
        {
            name: 'lars',
            age: 44.7,
            created: '2005-06-05T15:00:10.0000000'
        }
    ];

    describe('when sorting on string field', () => {
        it('should sort the list', () => {
            const expected = [
                {
                    name: 'alfie',
                    age: 66,
                    created: '2010-06-05T15:00:10.0000000'
                },
                {
                    name: 'lars',
                    age: 44.7,
                    created: '2005-06-05T15:00:10.0000000'
                },
                {
                    name: 'zara',
                    age: 44.1,
                    created: '2000-06-05T15:00:10.0000000'
                }
            ];

            expect(sortEntityList(entityList, 'name')).toEqual(expected);
        });
    });

    describe('when sorting on number field', () => {
        it('should sort the list', () => {
            const expected = [
                {
                    name: 'zara',
                    age: 44.1,
                    created: '2000-06-05T15:00:10.0000000'
                },
                {
                    name: 'lars',
                    age: 44.7,
                    created: '2005-06-05T15:00:10.0000000'
                },
                {
                    name: 'alfie',
                    age: 66,
                    created: '2010-06-05T15:00:10.0000000'
                }
            ];

            expect(sortEntityList(entityList, 'age')).toEqual(expected);
        });
    });

    describe('when sorting on invalid field', () => {
        it('should not sort entity list', () => {
            const expected = [
                {
                    name: 'zara',
                    age: 44.1,
                    created: '2000-06-05T15:00:10.0000000'
                },
                {
                    name: 'alfie',
                    age: 66,
                    created: '2010-06-05T15:00:10.0000000'
                },
                {
                    name: 'lars',
                    age: 44.7,
                    created: '2005-06-05T15:00:10.0000000'
                }
            ];

            expect(sortEntityList(entityList, 'height')).toEqual(expected);
        });
    });

    describe('when sorting on iso string field', () => {
        it('should sort the list', () => {
            const expected = [
                {
                    name: 'zara',
                    age: 44.1,
                    created: '2000-06-05T15:00:10.0000000'
                },
                {
                    name: 'lars',
                    age: 44.7,
                    created: '2005-06-05T15:00:10.0000000'
                },
                {
                    name: 'alfie',
                    age: 66,
                    created: '2010-06-05T15:00:10.0000000'
                }
            ];

            expect(sortEntityList(entityList, 'created')).toEqual(expected);
        });
    });
});

describe('when sorting a list', () => {
    describe('when sorting', () => {
        it('should sort the list', () => {
            const list = ['zara', 'alfie', 'lars'];

            const expected = ['alfie', 'lars', 'zara'];

            expect(sortList(list)).toEqual(expected);
        });
    });

    describe('when sorting on a iso string', () => {
        it('should sort the list', () => {
            const list = [
                '2005-06-05T15:00:10.0000000',
                '2010-06-05T15:00:10.0000000',
                '2000-06-05T15:00:10.0000000'
            ];

            const expected = [
                '2000-06-05T15:00:10.0000000',
                '2005-06-05T15:00:10.0000000',
                '2010-06-05T15:00:10.0000000'
            ];

            expect(sortList(list)).toEqual(expected);
        });
    });
});
