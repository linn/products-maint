import { getSernosNote } from '../sernosNotesSelectors';

describe('when getting a sernos note with matching serial number', () => {
    it('should return matching note', () => {
        const sernosNotes = [
            {
                sernosGroup: 'KLIMAX350',
                sernosNoteId: 30437,
                sernosNotes: 'ISSUED',
                sernosNumber: 1251636,
                sernosTRef: 2073318,
                transCode: 'DUM ISSUED'
            },
            {
                sernosGroup: 'KLOUT',
                sernosNoteId: 55,
                sernosNotes: 'UK ONLY TRANSFORMERS',
                sernosNumber: 2222,
                sernosTRef: 304747,
                transCode: 'BUILT'
            }
        ];

        const serialNumber = {
            articleNumber: '350/K/PBL/A',
            sernosGroup: 'KLIMAX350',
            sernosNumber: 1251636,
            sernosTRef: 2073318,
            transCode: 'DUM ISSUED'
        };

        const expected = {
            sernosGroup: 'KLIMAX350',
            sernosNoteId: 30437,
            sernosNotes: 'ISSUED',
            sernosNumber: 1251636,
            sernosTRef: 2073318,
            transCode: 'DUM ISSUED'
        };

        expect(getSernosNote(sernosNotes, serialNumber)).toEqual(expected);
    });
});

describe('when there is no note for the serial number', () => {
    it('should return null', () => {
        const sernosNotes = [
            {
                sernosGroup: 'KLOUT',
                sernosNoteId: 55,
                sernosNotes: 'UK ONLY TRANSFORMERS',
                sernosNumber: 2222,
                sernosTRef: 304747,
                transCode: 'BUILT'
            }
        ];

        const serialNumber = {
            articleNumber: '350/K/PBL/A',
            sernosGroup: 'KLIMAX350',
            sernosNumber: 1251636,
            sernosTref: 2073318,
            transCode: 'DUM ISSUED'
        };

        const expected = null;

        expect(getSernosNote(sernosNotes, serialNumber)).toEqual(expected);
    });
});
