import config from '../config';
import * as actionTypes from '.';
import { CALL_API } from 'redux-api-middleware';

export const fetchTariffs = () => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/products/maint/tariffs`,
        method: 'GET',
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_TARIFFS,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_TARIFFS,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) => res ? `Tariffs - ${res.status} ${res.statusText}` : `Network request failed`,
            }
        ]
    }
});