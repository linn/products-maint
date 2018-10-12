import config from '../config';
import * as actionTypes from './index';
import { CALL_API } from 'redux-api-middleware';

export const fetchCartonType = cartonTypeId => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/products/maint/carton-types/${cartonTypeId}`,
        method: 'GET',
        options: { requiresAuth: true },
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_CARTON_TYPE,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_CARTON_TYPE,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) => res ? `Error - ${res.status} ${res.statusText}` : `Network request failed`
            }
        ]
    }
});

export const addCartonType = carton => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/products/maint/carton-types`,
        method: 'POST',
        options: { requiresAuth: true },
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(carton),
        types: [
            {
                type: actionTypes.REQUEST_ADD_CARTON_TYPE,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_NEW_CARTON_TYPE,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) => res ? `Error - ${res.status} ${res.statusText}` : `Network request failed`
            }
        ]
    }
});

export const updateCartonType = (cartonTypeId, carton) => ({
    [CALL_API]: {
        endpoint: encodeURI(`${config.appRoot}/products/maint/carton-types/${cartonTypeId}`),
        method: 'PUT',
        options: { requiresAuth: true },
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(carton),
        types: [
            {
                type: actionTypes.REQUEST_UPDATE_CARTON_TYPE,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_CARTON_TYPE,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) => res ? `Error - ${res.status} ${res.statusText}` : `Network request failed`
            }
        ]
    }
});
