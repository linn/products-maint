import { CALL_API } from 'redux-api-middleware';
import config from '../config';
import * as sharedActionTypes from './index';

export default function ReportActions(actionTypeRoot, uri, actionTypes) {
    this.fetchReport = () => ({
        [CALL_API]: {
            endpoint: `${config.appRoot}${uri}`,
            method: 'GET',
            options: { requiresAuth: true },
            headers: {
                Accept: 'application/json'
            },
            types: [
                {
                    type: actionTypes[`REQUEST_${actionTypeRoot}_REPORT`],
                    payload: {}
                },
                {
                    type: actionTypes[`RECEIVE_${actionTypeRoot}_REPORT`],
                    payload: async (action, state, res) => ({ data: await res.json() })
                },
                {
                    type: sharedActionTypes.FETCH_ERROR,
                    payload: (action, state, res) =>
                        res ? `Report - ${res.status} ${res.statusText}` : `Network request failed`
                }
            ]
        }
    });
}
