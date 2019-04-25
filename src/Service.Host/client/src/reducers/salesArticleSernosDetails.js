import {
    REQUEST_SALES_ARTICLE_SERNOS_DETAILS,
    RECEIVE_SALES_ARTICLE_SERNOS_DETAILS
} from '../actions/index';

const defaultState = {
    loading: false,
    data: null
};

function salesArticleSernosDetails(state = defaultState, action) {
    switch (action.type) {
        case REQUEST_SALES_ARTICLE_SERNOS_DETAILS:
            return {
                ...state,
                loading: true,
                data: null
            };
        case RECEIVE_SALES_ARTICLE_SERNOS_DETAILS:
            return {
                ...state,
                loading: false,
                data: action.payload.data
            };
        default:
            return state;
    }
}

export default salesArticleSernosDetails;
