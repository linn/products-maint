import { getSerialNumberedSalesArticles } from '../salesArticlesSelectors';

describe('when getting serial numbered sales articles', () => {
    it('should return an array of serial numbered sales articles', () => {
        const state = {
            salesArticles: {
                items: [
                    {
                        typeOfSerialNumber: 'P1'
                    },
                    {
                        typeOfSerialNumber: 'P2'
                    },
                    {
                        typeOfSerialNumber: 'S'
                    },
                    {
                        typeOfSerialNumber: 'N'
                    }
                ]
            }
        };

        const expected = [
            {
                typeOfSerialNumber: 'P1'
            },
            {
                typeOfSerialNumber: 'P2'
            },
            {
                typeOfSerialNumber: 'S'
            }
        ];

        expect(getSerialNumberedSalesArticles(state)).toEqual(expected);
    });

    it('should return an empty array when there are no serial numbered sales articles', () => {
        const state = {
            salesArticles: {
                items: [
                    {
                        typeOfSerialNumber: 'N'
                    }
                ]
            }
        };

        const expected = [];

        expect(getSerialNumberedSalesArticles(state)).toEqual(expected);
    });

    it('should return null when there are no sales articles', () => {
        const state = {
            salesArticles: {
                items: []
            }
        };

        const expected = null;

        expect(getSerialNumberedSalesArticles(state)).toEqual(expected);
    });
});
