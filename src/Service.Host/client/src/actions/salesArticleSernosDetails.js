import { RSAA } from 'redux-api-middleware';
import config from '../config';
import * as actionTypes from './index';

export const fetchSalesArticleSernosDetails = articleNumber => ({
    [RSAA]: {
        endpoint: `${config.appRoot}/products/maint/sales-articles/serial-number-details/${articleNumber}`,
        method: 'GET',
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_SALES_ARTICLE_SERNOS_DETAILS,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_SALES_ARTICLE_SERNOS_DETAILS,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: async (action, state, res) =>
                    res
                        ? {
                              error: {
                                  status: res.status,
                                  statusText: `Error - ${res.status} ${res.statusText}`,
                                  details: await res.json()
                              }
                          }
                        : `Network request failed`
            }
        ]
    }
});

export const clearSalesArticleSernosDetails = () => ({
    type: actionTypes.CLEAR_SALES_ARTICLE_SERNOS_DETAILS,
    payload: {}
});
