import config from '../config';
import * as actionTypes from '.';
import { CALL_API } from 'redux-api-middleware';

let timeoutId;

export const fetchTariffs = searchTerm => async dispatch => {
    if (searchTerm) {
        if (timeoutId) {
            clearTimeout(timeoutId);
        }
        timeoutId = setTimeout(async () => {
            dispatch(performTariffSearch(searchTerm));
        }, 500);
    }
};

const performTariffSearch = searchTerm => ({
    [CALL_API]: {
        endpoint: `${config.appRoot}/products/maint/tariffs?searchTerm=${searchTerm}`,
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

const setTariffSearchTermCreator = searchTerm => ({
    type: actionTypes.SET_TARIFF_SEARCH_TERM,
    payload: searchTerm
});

export const setTariffSearchTerm = searchTerm => dispatch => {
    dispatch(setTariffSearchTermCreator(searchTerm));
    dispatch(fetchTariffs());
};