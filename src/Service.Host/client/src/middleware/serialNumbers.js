import * as actionTypes from '../actions';
import sernosNotesActions from '../actions/sernosNotesActions';
import sernosNoteActions from '../actions/sernosNoteActions';

const fetchSernosNotes = (sernosNumber, dispatch) => {
    const sernosNotesHref = `/products/maint/serial-numbers/notes?sernosNumber=${sernosNumber}`;
    dispatch(sernosNotesActions.fetchByHref(sernosNotesHref));
};

const fetchSernosNotesFromSerialNumber = (data, dispatch) => {
    if (data.length) {
        const { sernosNumber } = data[0];
        fetchSernosNotes(sernosNumber, dispatch);
    }
};

const fetchSernosNoteFromSernosNote = (data, dispatch) => {
    const { sernosNumber } = data;
    fetchSernosNotes(sernosNumber, dispatch);
};

const createSernosNote = (data, dispatch) => {
    // TODO test
    const { serialNumber } = data;
    if (serialNumber.sernosNotes) {
        const sernosNote = {
            sernosNotes: serialNumber.sernosNotes,
            sernosGroup: serialNumber.sernosGroup,
            sernosNumber: serialNumber.sernosNumber,
            sernosTRef: serialNumber.sernosTRef,
            transCode: serialNumber.transCode
        };
        dispatch(sernosNoteActions.add(sernosNote));
    }
};

export default ({ dispatch }) => next => action => {
    const result = next(action);

    switch (action.type) {
        case actionTypes.serialNumbersActionTypes.RECEIVE_SERIAL_NUMBERS:
            fetchSernosNotesFromSerialNumber(action.payload.data, dispatch);
            break;
        case actionTypes.sernosNoteActionTypes.RECEIVE_UPDATED_SERNOS_NOTE:
        case actionTypes.sernosNoteActionTypes.RECEIVE_NEW_SERNOS_NOTE:
            fetchSernosNoteFromSernosNote(action.payload.data, dispatch);
            break;
        case actionTypes.serialNumberActionTypes.RECEIVE_NEW_SERIAL_NUMBER:
            createSernosNote(action.data.payload, dispatch);
            break;
        default:
    }

    return result;
};
