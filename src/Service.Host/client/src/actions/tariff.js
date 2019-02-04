import { CALL_API } from 'redux-api-middleware';
import config from '../config';
import * as actionTypes from '.';

export const fetchTariff = (id) => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/products/maint/tariffs/${id}`,
        method: 'GET',
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_TARIFF,
                payload: { data: `/products/maint/tariffs/${id}` }
            },
            {
                type: actionTypes.RECEIVE_TARIFF,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) => res ? `Tariff - ${res.status} ${res.statusText}` : `Network request failed`
            }
        ]
    }
});

export const addTariff = tariff => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/products/maint/tariffs`,
        method: 'POST',
        options: { requiresAuth: true },
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(tariff),
        types: [
            {
                type: actionTypes.REQUEST_ADD_TARIFF,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_NEW_TARIFF,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: async (action, state, res) => res ? { error: { status: res.status, statusText: `Error - ${res.status} ${res.statusText}`, details: await res.json() } } : `Network request failed`
            }
        ]
    }
});

export const updateTariff = (id, tariff) => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/products/maint/tariffs/${id}`,
        method: 'PUT',
        options: { requiresAuth: true },
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(tariff),
        types: [
            {
                type: actionTypes.REQUEST_UPDATE_TARIFF,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_TARIFF,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: async (action, state, res) => res ? { error: { status: res.status, statusText: `Error - ${res.status} ${res.statusText}`, details: await res.json() } } : `Network request failed`
            }
        ]
    }
});
