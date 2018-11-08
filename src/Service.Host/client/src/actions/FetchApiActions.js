import config from '../config';
import * as sharedActionTypes from './index';
import { CALL_API } from 'redux-api-middleware';

export default function FetchApiActions(actionTypeRoot, uri, actionTypes) {
    //TODO take query parameters
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
                    payload: (action, state, res) => res ? `Error - ${res.status} ${res.statusText}` : `Network request failed`
                }
            ]
        }
    });
}
