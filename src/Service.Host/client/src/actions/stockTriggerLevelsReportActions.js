import { CALL_API } from 'redux-api-middleware';
import config from '../config';
import * as actionTypes from './index';

export const fetchStockTriggerLevelParts = (locationId) => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/products/reports/parts-at-location/${locationId}`,
        method: 'GET',
        options: { requiresAuth: true },
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_STOCK_TRIGGER_LEVELS_REPORT,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_STOCK_TRIGGER_LEVELS_REPORT,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) => res ? `Report - ${res.status} ${res.statusText}` : `Network request failed`
            }
        ]
    }
});

export const fetchStockTriggerLevelsByPart = (partNumber) => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/products/reports/stock-trigger-levels/18104/${partNumber}`,
        method: 'GET',
        options: { requiresAuth: true },
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_STOCK_TRIGGER_LEVELS_REPORT,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_STOCK_TRIGGER_LEVELS_REPORT,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) => res ? `Report - ${res.status} ${res.statusText}` : `Network request failed`
            }
        ]
    }
});
