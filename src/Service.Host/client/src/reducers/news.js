import { REQUEST_NEWS, RECEIVE_NEWS } from '../actions/index';

function news(state = { loading: false, data: null }, action) {
    switch (action.type) {
        case REQUEST_NEWS:
            return {
                ...state,
                loading: true,
                data: null
            };

        case RECEIVE_NEWS:
            return {
                ...state,
                loading: false,
                data: action.payload.news
            };

        default:
            return state;
    }
}

export default news;
