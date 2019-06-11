import { RSAA } from 'redux-api-middleware';
import config from '../config';
import * as actionTypes from './index';

const fetchMenu = () => ({
    [RSAA]: {
        endpoint: `${config.proxyRoot}/intranet/menu-no-auth`,
        method: 'GET',
        options: { requiresAuth: false },
       
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
