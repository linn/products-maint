import { RSAA } from 'redux-api-middleware';
import config from '../config';
import * as actionTypes from './index';

const fetchProductsOnHold = () => ({
    [RSAA]: {
        endpoint: `${config.appRoot}/products/reports/products-on-hold`,
        method: 'GET',
        options: { requiresAuth: true },
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_PRODUCTS_ON_HOLD_REPORT,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_PRODUCTS_ON_HOLD_REPORT,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) =>
                    res ? `Report - ${res.status} ${res.statusText}` : `Network request failed`
            }
        ]
    }
});

export default fetchProductsOnHold;
