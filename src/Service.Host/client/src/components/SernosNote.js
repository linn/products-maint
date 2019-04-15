import React, { useEffect, useState, Fragment } from 'react';
import PropTypes from 'prop-types';
import EditIcon from '@material-ui/icons/Edit';
import Clear from '@material-ui/icons/Clear';
import Done from '@material-ui/icons/Done';
import { Button, TableRow, TableCell } from '@material-ui/core';
import { InputField } from '@linn-it/linn-form-components-library';
import moment from 'moment';
import { getSelfHref } from '../helpers/utilities';

function SernosNote({ serialNumber, item, updateSernosNote, addSernosNote }) {
    const [editing, setEditing] = useState(false);
    const [sernosNote, setSernosNote] = useState({});
    const [prevSernosNote, setPrevSernosNote] = useState({});

    useEffect(() => {
        if (item !== prevSernosNote) {
            if (item !== null) {
                setSernosNote(item);
                setPrevSernosNote(item);
            } else {
                setSernosNote({
                    sernosNotes: '',
                    sernosGroup: serialNumber.sernosGroup,
                    sernosNumber: serialNumber.sernosNumber,
                    sernosTRef: serialNumber.sernosTRef,
                    transCode: serialNumber.transCode
                });
                setPrevSernosNote(item);
            }
        }
    }, [item, serialNumber, prevSernosNote]);

    const sernosNoteInvalid = () => !sernosNote.sernosNotes;

    const handleFieldChange = (propertyName, newValue) => {
        setSernosNote({ ...sernosNote, [propertyName]: newValue });
    };

    const handleSaveClick = () => {
        const href = getSelfHref(sernosNote);
        if (href) {
            updateSernosNote(sernosNote.sernosNoteId, sernosNote);
        } else {
            addSernosNote(sernosNote);
        }
    };

    return (
        <TableRow key={serialNumber.sernosTRef}>
            <TableCell component="th" scope="row">
                {serialNumber.sernosDate
                    ? moment(serialNumber.sernosDate).format('DD MMM YYYY')
                    : ''}
            </TableCell>
            <TableCell>{serialNumber.transCode}</TableCell>
            <TableCell>{serialNumber.documentNumber}</TableCell>
            <TableCell>{serialNumber.articleNumber}</TableCell>
            {editing ? (
                <Fragment>
                    <TableCell>
                        <InputField
                            label="Notes"
                            fullWidth
                            error={sernosNoteInvalid()}
                            helperText={sernosNoteInvalid() ? 'This field is required' : ''}
                            value={sernosNote.sernosNotes}
                            onChange={handleFieldChange}
                            propertyName="sernosNotes"
                            maxLength={2000}
                        />
                    </TableCell>
                    <TableCell>
                        <Button disabled={sernosNoteInvalid()} onClick={handleSaveClick}>
                            <Done />
                        </Button>
                        <Button
                            onClick={() => {
                                setEditing(false);
                                setSernosNote(prevSernosNote);
                            }}
                        >
                            <Clear />
                        </Button>
                    </TableCell>
                </Fragment>
            ) : (
                <Fragment>
                    <TableCell>{sernosNote.sernosNotes}</TableCell>
                    <TableCell>
                        <Button onClick={() => setEditing(true)}>
                            <EditIcon />
                        </Button>
                    </TableCell>
                </Fragment>
            )}
        </TableRow>
    );
}

SernosNote.propTypes = {
    item: PropTypes.shape({}),
    serialNumber: PropTypes.shape({}).isRequired,
    updateSernosNote: PropTypes.func.isRequired,
    addSernosNote: PropTypes.func.isRequired
};

SernosNote.defaultProps = {
    item: {}
};

export default SernosNote;
