﻿import { utilities } from '@linn-it/linn-form-components-library';
import * as actionTypes from '../actions';
import saCoreTypeActions from '../actions/saCoreTypeActions';

const fetchSaCoreType = (data, dispatch) => {
    const saCoreTypeHref = utilities.getHref(data, 'sa-core-type');
    if (saCoreTypeHref) {
        dispatch(saCoreTypeActions.fetchByHref(saCoreTypeHref));
    }
};

export default ({ dispatch }) => next => action => {
    const result = next(action);

    switch (action.type) {
        case actionTypes.salesArticleActionTypes.RECEIVE_SALES_ARTICLE:
            fetchSaCoreType(action.payload.data, dispatch);
            break;
        default:
    }

    return result;
};
