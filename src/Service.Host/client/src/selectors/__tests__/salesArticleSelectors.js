import { getArticleType } from '../salesArticleSelectors';

describe('when getting sales article article type', () => {
    it('should return article type', () => {
        const state = {
            salesArticle: {
                item: {
                    typeOfSerialNumber: 'P1'
                }
            }
        };

        const expected = 'P1';

        expect(getArticleType(state)).toEqual(expected);
    });

    it('should return null when no article item', () => {
        const state = {
            salesArticle: {
                item: null
            }
        };

        expect(getArticleType(state)).toEqual(null);
    });
});
