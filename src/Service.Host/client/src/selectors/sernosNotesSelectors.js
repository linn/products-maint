import { CollectionSelectors } from '@linn-it/linn-form-components-library';
import * as itemTypes from '../itemTypes';

export const getSernosNote = (sernosNotes, serialNumber) => {
    if (!sernosNotes || !serialNumber) {
        return null;
    }

    const sernosNote = sernosNotes.find(
        note =>
            note.sernosTRef === serialNumber.sernosTRef &&
            note.sernosNumber === serialNumber.sernosNumber &&
            note.sernosGroup === serialNumber.sernosGroup &&
            note.transCode === serialNumber.transCode
    );

    return sernosNote || null;
};

export default new CollectionSelectors(itemTypes.sernosNotes.item);
