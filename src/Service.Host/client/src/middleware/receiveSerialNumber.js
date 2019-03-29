import * as actionTypes from '../actions';
import { getHref } from '../helpers/utilities';
import salesArticleActions from '../actions/salesArticle';
import sernosNoteActions from '../actions/sernosNoteActions';

const fetchSalesArticle = (data, dispatch) => {
    const salesArticleHref = getHref(data, 'sales-article');
    if (salesArticleHref) {
        dispatch(salesArticleActions.fetchByHref(salesArticleHref));
    }
};

const fetchSernosNote = (data, dispatch) => {
    const sernosNoteHref = `/products/maint/serial-numbers/notes?sernosGroup=${
        data.sernosGroup
    }&sernosNumber=${data.sernosNumber}&transCode=${data.transCode}`;
    dispatch(sernosNoteActions.fetchByHref(sernosNoteHref));
};

export default ({ dispatch }) => next => action => {
    const result = next(action);

    switch (action.type) {
        case actionTypes.serialNumberActionTypes.RECEIVE_SERIAL_NUMBER:
            fetchSalesArticle(action.payload.data, dispatch);
            fetchSernosNote(action.payload.data, dispatch);
            break;
        default:
    }

    return result;
};
