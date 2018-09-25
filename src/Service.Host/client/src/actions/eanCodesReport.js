import config from '../config';
import * as actionTypes from './index';
import { CALL_API } from 'redux-api-middleware';

export const fetchEanCodesReport = (queryString) => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/products/reports/sales-article-ean-codes${queryString ? queryString : ''}`,
        method: 'GET',
        options: { requiresAuth: true },
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_EAN_CODE_REPORT,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_EAN_CODE_REPORT,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) => res ? `Ean Codes Report - ${res.status} ${res.statusText}` : `Network request failed`
            }
        ]
    }
});

