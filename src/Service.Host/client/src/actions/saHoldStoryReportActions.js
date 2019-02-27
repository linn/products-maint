import { CALL_API } from 'redux-api-middleware';
import config from '../config';
import * as actionTypes from './index';

const fetchSaHoldStoriesReport = articleNumber => ({
    [CALL_API]: {
        endpoint: `${
            config.appRoot
        }/products/reports/sa-hold-stories-for-sales-article/${articleNumber}`,
        method: 'GET',
        options: { requiresAuth: true },
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_SA_HOLD_STORIES_REPORT,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_SA_HOLD_STORIES_REPORT,
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

export default fetchSaHoldStoriesReport;
