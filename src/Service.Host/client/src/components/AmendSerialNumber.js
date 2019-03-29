import React, { Fragment, useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import { Grid } from '@material-ui/core';
import moment from 'moment';
import {
    SaveBackCancelButtons,
    InputField,
    Loading,
    Title,
    ErrorCard,
    SnackbarMessage
} from '@linn-it/linn-form-components-library';
import Page from '../containers/Page';

function AmendSerialNumber({
    editStatus,
    errorMessage,
    history,
    item,
    serialNumber,
    serialNumberloading,
    sernosNoteLoading,
    salesArticleLoading,
    snackbarVisible,
    setSnackbarVisible,
    salesArticle,
    setEditStatus,
    updateItem,
    addItem
}) {
    const [sernosNote, setSernosNote] = useState({});
    const [prevSernosNote, setPrevSernosNote] = useState({});

    useEffect(() => {
        if (item !== prevSernosNote) {
            // TODO sort this
            // setSernosNote(item);
            setPrevSernosNote(item);
        }
    }, [item, prevSernosNote]);

    // only have an edit status
    const creating = () => editStatus === 'create';
    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';

    const notesInvalid = () => !sernosNote.sernosNotes;

    const handleFieldChange = (propertyName, newValue) => {
        if (!creating) {
            setEditStatus('edit');
        }
        setSernosNote({ ...sernosNote, [propertyName]: newValue });
    };

    const handleSaveClick = () => {
        if (editing()) {
            updateItem(sernosNote.sernosNoteId, sernosNote);
            setEditStatus('view');
        } else if (creating()) {
            addItem(sernosNote);
            setEditStatus('view');
        }
    };

    const handleCancelClick = () => {
        setSernosNote(prevSernosNote);
        setEditStatus('view');
    };

    const handleBackClick = () => {
        history.push(`/products/maint/serial-numbers/${sernosNote.sernosNumber}`);
    };

    return (
        <Page>
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    <Title text="Amend Serial Number" />
                </Grid>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                {serialNumberloading ||
                sernosNoteLoading ||
                salesArticleLoading ||
                !serialNumber ? (
                    <Grid item xs={12}>
                        <Loading />
                    </Grid>
                ) : (
                    <Fragment>
                        <SnackbarMessage
                            visible={snackbarVisible}
                            onClose={() => setSnackbarVisible(false)}
                            message="Save Successful"
                        />
                        <Grid item xs={8}>
                            <InputField
                                fullWidth
                                disabled
                                value={serialNumber.sernosGroup}
                                label="Sernos Group"
                                propertyName="sernosGroup"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                fullWidth
                                disabled
                                value={serialNumber.sernosNumber}
                                label="Serial Number"
                                propertyName="sernosNumber"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                fullWidth
                                disabled
                                value={
                                    serialNumber.sernosDate
                                        ? moment(serialNumber.sernosDate).format('YYYY-MM-DD')
                                        : ''
                                }
                                label="Sernos Date"
                                propertyName="sernosDate"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                fullWidth
                                disabled
                                value={serialNumber.transCode}
                                label="Trans Code"
                                propertyName="transCode"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                fullWidth
                                disabled
                                value={serialNumber.articleNumber}
                                label="Article Number"
                                propertyName="articleNumber"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                fullWidth
                                disabled
                                value={salesArticle ? salesArticle.description : ''}
                                label="Description"
                                propertyName="description"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                fullWidth
                                maxLength={2000}
                                label="Notes"
                                propertyName="sernosNotes"
                                value={sernosNote ? sernosNote.sernosNotes : ''}
                                onChange={handleFieldChange}
                                error={notesInvalid()}
                                helperText={notesInvalid() ? 'This field is required' : ''}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <SaveBackCancelButtons
                                saveDisabled={viewing() || notesInvalid()}
                                saveClick={handleSaveClick}
                                cancelClick={handleCancelClick}
                                backClick={handleBackClick}
                            />
                        </Grid>
                    </Fragment>
                )}
            </Grid>
        </Page>
    );
}

export default AmendSerialNumber;
