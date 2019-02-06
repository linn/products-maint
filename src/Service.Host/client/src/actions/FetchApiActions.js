import { CALL_API } from 'redux-api-middleware';
import config from '../config';
import * as sharedActionTypes from './index';

export default function FetchApiActions(actionTypeRoot, uri, actionTypes) {
    this.fetch = () => ({
        [CALL_API]: {
            endpoint: `${config.appRoot}${uri}`,
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
                    payload: (action, state, res) =>
                        res ? `Error - ${res.status} ${res.statusText}` : `Network request failed`
                }
            ]
        }
    });

    this.search = searchTerm => ({
        [CALL_API]: {
            endpoint: `${config.appRoot}${uri}?searchTerm=${searchTerm}`,
            method: 'GET',
            options: { requiresAuth: true },
            headers: {
                Accept: 'application/json'
            },
            types: [
                {
                    type: actionTypes[`REQUEST_SEARCH_${actionTypeRoot}`],
                    payload: {}
                },
                {
                    type: actionTypes[`RECEIVE_SEARCH_${actionTypeRoot}`],
                    payload: async (action, state, res) => ({ data: await res.json() })
                },
                {
                    type: sharedActionTypes.FETCH_ERROR,
                    payload: (action, state, res) =>
                        res ? `Error - ${res.status} ${res.statusText}` : `Network request failed`
                }
            ]
        }
    });

    this.clearSearch = () => ({
        type: actionTypes[`CLEAR_SEARCH_${actionTypeRoot}`],
        payload: {}
    });
}
