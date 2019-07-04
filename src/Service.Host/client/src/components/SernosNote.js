import React, { useEffect, useState, Fragment } from 'react';
import PropTypes from 'prop-types';
import EditIcon from '@material-ui/icons/Edit';
import Clear from '@material-ui/icons/Clear';
import Done from '@material-ui/icons/Done';
import { Button, TableRow, TableCell } from '@material-ui/core';
import { InputField, getSelfHref } from '@linn-it/linn-form-components-library';
import moment from 'moment';
import { makeStyles } from '@material-ui/styles';

const useStyles = makeStyles(theme => ({
    cancelButton: {
        marginLeft: theme.spacing(1)
    }
}));

function SernosNote({ serialNumber, item, updateSernosNote, addSernosNote }) {
    const [editing, setEditing] = useState(false);
    const [sernosNote, setSernosNote] = useState({});
    const [prevSernosNote, setPrevSernosNote] = useState({});

    const classes = useStyles();

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

    const handleCancelClick = () => {
        setEditing(false);
        if (prevSernosNote) {
            setSernosNote(prevSernosNote);
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
                            fullWidth
                            required
                            helperText="This field is required"
                            label="Notes"
                            maxLength={2000}
                            propertyName="sernosNotes"
                            value={sernosNote.sernosNotes}
                            onChange={handleFieldChange}
                        />
                    </TableCell>
                    <TableCell>
                        <Button
                            disabled={sernosNoteInvalid()}
                            onClick={handleSaveClick}
                            color="primary"
                            variant="outlined"
                        >
                            <Done />
                        </Button>
                        <Button
                            onClick={handleCancelClick}
                            color="secondary"
                            variant="outlined"
                            classes={{
                                root: classes.cancelButton
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
                        <Button
                            color="primary"
                            aria-label="Edit"
                            variant="outlined"
                            onClick={() => setEditing(true)}
                        >
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
