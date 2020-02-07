import { RSAA } from 'redux-api-middleware';
import config from '../config';
import * as actionTypes from './index';

export const fetchSaHoldStoriesReport = articleNumber => ({
    [RSAA]: {
        endpoint: `${config.appRoot}/products/reports/sa-hold-stories-for-sales-article/${articleNumber}`,
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

export const fetchRootProductHoldStoriesReport = rootProduct => ({
    [RSAA]: {
        endpoint: `${config.appRoot}/products/reports/hold-stories-for-root-product/${rootProduct}`,
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
