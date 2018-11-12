﻿import config from '../config';
import * as sharedActionTypes from './index';
import { CALL_API } from 'redux-api-middleware';

export default function UpdateApiActions(actionTypeRoot, uri, actionTypes) {
    this.fetch = id => ({
        [CALL_API]: {
            endpoint: `${config.appRoot}${uri}/${id}`,
            method: 'GET',
            options: { requiresAuth: true },
            headers: {
                Accept: 'application/json'
            },
            types: [
                {
                    type: actionTypes[`REQUEST_${actionTypeRoot}`],
                    payload: {}
                },
                {
                    type: actionTypes[`RECEIVE_${actionTypeRoot}`],
                    payload: async (action, state, res) => ({ data: await res.json() })
                },
                {
                    type: sharedActionTypes.FETCH_ERROR,
                    payload: (action, state, res) => res ? `Error - ${res.status} ${res.statusText}` : `Network request failed`
                }
            ]
        }
    });

    this.add = item => ({
        [CALL_API]: {
            endpoint: `${config.appRoot}${uri}`,
            method: 'POST',
            options: { requiresAuth: true },
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(item),
            types: [
                {
                    type: actionTypes[`REQUEST_ADD_${actionTypeRoot}`],
                    payload: {}
                },
                {
                    type: actionTypes[`RECEIVE_NEW_${actionTypeRoot}`],
                    payload: async (action, state, res) => ({ data: await res.json() })
                },
                {
                    type: sharedActionTypes.FETCH_ERROR,
                    payload: async (action, state, res) => res ? { error: { status: res.status, statusText: `Error - ${res.status} ${res.statusText}`, details: await res.json() } } : `Network request failed`
                }
            ]
        }
    });

    this.update = (id, item) => ({
        [CALL_API]: {
            endpoint: encodeURI(`${config.appRoot}${uri}/${id}`),
            method: 'PUT',
            options: { requiresAuth: true },
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(item),
            types: [
                {
                    type: actionTypes[`REQUEST_UPDATE_${actionTypeRoot}`],
                    payload: {}
                },
                {
                    type: actionTypes[`RECEIVE_${actionTypeRoot}`],
                    payload: async (action, state, res) => ({ data: await res.json() })
                },
                {
                    type: sharedActionTypes.FETCH_ERROR,
                    payload: async (action, state, res) => res ? { error: { status: res.status, statusText: `Error - ${res.status} ${res.statusText}`, details: await res.json() } } : `Network request failed`
                }
            ]
        }
    });

    this.reset = () => ({
        type: actionTypes[`RESET_${actionTypeRoot}`],
        payload: {}
    });
}