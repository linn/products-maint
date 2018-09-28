import config from '../config';
import * as actionTypes from './index';
import { CALL_API } from 'redux-api-middleware';

export const fetchProductRangesReport = (includePhasedOut) => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/products/reports/product-ranges?includePhasedOut=${includePhasedOut}`,
        method: 'GET',
        options: { requiresAuth: true },
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_PRODUCT_RANGES_REPORT,
                payload: {
                    options: { includePhasedOut }}
            },
            {
                type: actionTypes.RECEIVE_PRODUCT_RANGES_REPORT,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) => res ? `Report - ${res.status} ${res.statusText}` : `Network request failed`
            }
        ]
    }
});

