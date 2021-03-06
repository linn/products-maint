import { RSAA } from 'redux-api-middleware';
import config from '../config';
import * as actionTypes from './index';

export const fetchNews = () => ({
    [RSAA]: {
        endpoint: `${config.appRoot}/notifications`,
        method: 'GET',
        options: { requiresAuth: false },
        headers: {
            Accept: 'application/json'
        },
        types: [
            {
                type: actionTypes.REQUEST_NEWS,
                payload: {}
            },
            {
                type: actionTypes.RECEIVE_NEWS,
                payload: async (action, state, res) => ({ news: await res.json() })
            },
            {
                type: actionTypes.FETCH_ERROR,
                payload: (action, state, res) =>
                    res ? `Report - ${res.status} ${res.statusText}` : `Network request failed`
            }
        ]
    }
});

export const markNotificationSeen = e => ({
    type: 'MARK_NOTIFICATION_SEEN',
    title: e.title
});
