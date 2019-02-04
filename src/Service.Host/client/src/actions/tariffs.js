import { CALL_API } from 'redux-api-middleware';
import config from '../config';
import * as actionTypes from '.';

let timeoutId;

const performTariffSearch = searchTerm => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/products/maint/tariffs?searchTerm=${searchTerm}`,
        method: 'GET',
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_SEARCH_TARIFFS,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_SEARCH_TARIFFS,
                payload: async (action, state, res) => ({ data: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) => res ? `Tariffs - ${res.status} ${res.statusText}` : `Network request failed`
            }
        ]
    }
});

export default searchTerm => async dispatch => {
    if (searchTerm) {
        if (timeoutId) {
            clearTimeout(timeoutId);
        }
        timeoutId = setTimeout(async () => {
            dispatch(performTariffSearch(searchTerm));
        }, 500);
    }
};
