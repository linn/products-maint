import config from '../config';
import * as actionTypes from './index';
import { CALL_API } from 'redux-api-middleware';

export const fetchSalesProductsByProductRangeReport = (productRangeId, includePhasedOut) => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/products/reports/sales-products-by-product-range?includePhasedOut=${includePhasedOut}&productRangeId=${productRangeId}`,
        method: 'GET',
        options: { requiresAuth: true },
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_SALES_PRODUCTS_BY_RANGE_REPORT,
                payload: {
                    options: { includePhasedOut, productRangeId }
                }
            },
            {
                type: actionTypes.RECEIVE_SALES_PRODUCTS_BY_RANGE_REPORT,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) => res ? `Report - ${res.status} ${res.statusText}` : `Network request failed`
            }
        ]
    }
});

