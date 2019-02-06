import { CALL_API } from 'redux-api-middleware';
import config from '../config';
import * as actionTypes from './index';

export default (includePhasedOut, cartonisedOnly) => ({
    [CALL_API]: {
        endpoint: `${
            config.appRoot
        }/products/reports/sales-article-ean-codes?includePhasedOut=${includePhasedOut}&cartonisedOnly=${cartonisedOnly}`,
        method: 'GET',
        options: { requiresAuth: true },
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_EAN_CODE_REPORT,
                payload: {
                    options: { includePhasedOut, cartonisedOnly }
                }
            },
            {
                type: actionTypes.RECEIVE_EAN_CODE_REPORT,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) =>
                    res
                        ? `Ean Codes Report - ${res.status} ${res.statusText}`
                        : `Network request failed`
            }
        ]
    }
});
