import { CALL_API } from 'redux-api-middleware';
import config from '../config';
import * as actionTypes from './index';

export default () => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/products/reports/carton-details`,
        method: 'GET',
        options: { requiresAuth: true },
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_CARTON_DETAILS_REPORT,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_CARTON_DETAILS_REPORT,
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
