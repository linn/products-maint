import deepFreeze from 'deep-freeze';
import salesArticleSernosDetails from '../salesArticleSernosDetails';

describe('sales article sernos details reducer', () => {
    const actionTypes = {
        REQUEST_SALES_ARTICLE_SERNOS_DETAILS: 'REQUEST_SALES_ARTICLE_SERNOS_DETAILS',
        RECEIVE_SALES_ARTICLE_SERNOS_DETAILS: 'RECEIVE_SALES_ARTICLE_SERNOS_DETAILS'
    };

    test('when requesting sales article sernos details', () => {
        const state = {
            loading: false,
            data: null
        };

        const action = {
            type: actionTypes.REQUEST_SALES_ARTICLE_SERNOS_DETAILS,
            payload: {}
        };

        const expected = {
            loading: true,
            data: null
        };

        deepFreeze(state);

        expect(salesArticleSernosDetails(state, action)).toEqual(expected);
    });

    test('when receiving sales article sernos details', () => {
        const state = {
            loading: true,
            data: null
        };

        const action = {
            type: actionTypes.RECEIVE_SALES_ARTICLE_SERNOS_DETAILS,
            payload: {
                data: {
                    serialNumberType: 'type',
                    sernosGroup: 'group'
                }
            }
        };

        const expected = {
            loading: false,
            data: {
                serialNumberType: 'type',
                sernosGroup: 'group'
            }
        };

        deepFreeze(state);

        expect(salesArticleSernosDetails(state, action)).toEqual(expected);
    });
});
