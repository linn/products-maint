import { CALL_API } from 'redux-api-middleware';
import config from '../config';
import * as actionTypes from './index';

const fetchMenu = () => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/intranet/menu-no-auth`,
        method: 'GET',
        options: { requiresAuth: false },
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_MENU,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_MENU,
                payload: async (action, state, res) => ({ menu: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) =>
                    res ? `Report - ${res.status} ${res.statusText}` : `Network request failed`
            }
        ]
    }
});

export default fetchMenu;
