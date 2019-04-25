import { CALL_API } from 'redux-api-middleware';
import config from '../config';
import * as actionTypes from './index';

const fetchSalesArticleSernosDetails = articleNumber => {
    return {
        [CALL_API]: {
            endpoint: `${
                config.appRoot
            }/products/maint/sales-articles/serial-number-details/${articleNumber}`,
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
                    payload: (action, state, res) =>
                        res ? `${res.status} ${res.statusText}` : `Network request failed`
                }
            ]
        }
    };
};

export default fetchSalesArticleSernosDetails;
