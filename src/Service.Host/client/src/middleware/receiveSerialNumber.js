import * as actionTypes from '../actions';
import sernosNotesActions from '../actions/sernosNotesActions';

const fetchSernosNotes = (data, dispatch) => {
    if (data.length) {
        const { sernosNumber } = data[0];
        const sernosNotesHref = `/products/maint/serial-numbers/notes?sernosNumber=${sernosNumber}`;
        dispatch(sernosNotesActions.fetchByHref(sernosNotesHref));
    }
};

export default ({ dispatch }) => next => action => {
    const result = next(action);

    switch (action.type) {
        case actionTypes.serialNumbersActionTypes.RECEIVE_SERIAL_NUMBERS:
            fetchSernosNotes(action.payload.data, dispatch);
            break;
        default:
    }

    return result;
};
