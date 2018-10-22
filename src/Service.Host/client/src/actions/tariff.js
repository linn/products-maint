import config from '../config';
import * as actionTypes from '.';
import { CALL_API } from 'redux-api-middleware';

export const fetchTariff = (tariffUri) => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}${tariffUri}`,
        method: 'GET',
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_TARIFF,
                payload: { data: tariffUri }
            },
            {
                type: actionTypes.RECEIVE_TARIFF,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) => res ? `Tariff - ${res.status} ${res.statusText}` : `Network request failed`,
            }
        ],
    }
});