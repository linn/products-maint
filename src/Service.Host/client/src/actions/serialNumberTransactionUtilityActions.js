import { CALL_API } from 'redux-api-middleware';
import config from '../config';
import * as sharedActionTypes from './index';


import { FetchApiActions } from '@linn-it/linn-form-components-library';
import { serialNumberTransactionsActionTypes as actionTypes } from './index';
import * as itemTypes from '../itemTypes';
import config from '../config';

export default new FetchApiActions(
    itemTypes.serialNumberTransCount.actionType,
    itemTypes.serialNumberTransCount.uri,
    actionTypes,
    config.appRoot
);

const getSernosTransCodes = () => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/products/maint/serial-number-counts`,
        method: 'GET',
        options: { requiresAuth: true },
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: 'REQUEST_SERIAL_NUMBER_COUNTS',
                payload: {}
            },
            {
                type: 'RECEIVE_SERIAL_NUMBER_COUNTS',
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

export default getSernosTransCodes;
