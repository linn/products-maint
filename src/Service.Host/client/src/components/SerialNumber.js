import React, { Fragment, useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';
import { Grid } from '@material-ui/core';
import {
    SaveBackCancelButtons,
    InputField,
    Loading,
    Title,
    ErrorCard,
    SnackbarMessage,
    Dropdown
} from '@linn-it/linn-form-components-library';
import Page from '../containers/Page';

function SerialNumber({
    errorMessage,
    editStatus,
    history,
    loading,
    itemId,
    item,
    snackbarVisible,
    addItem,
    setEditStatus,
    updateItem,
    setSnackbarVisible
}) {
    const [serialNumber, setSerialNumber] = useState({});
    const [prevSerialNumber, setPrevSerialNumber] = useState({});

    // TODO effects for aticles and groups coming in
    // when different set the fields in serialNumber
    // test on if the fields have changed
    useEffect(() => {
        if (item !== prevSerialNumber) {
            setSerialNumber(item);
            setPrevSerialNumber(item);
        }
    }, [item, prevSerialNumber]);

    const creating = () => editStatus === 'create';
    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';

    const articles = ['', 'please', 'fetch', 'me'];

    const handleFieldChange = (propertyName, newValue) => {
        setEditStatus('edit');
        setSerialNumber({ ...serialNumber, [propertyName]: newValue });
    };

    return (
        <Page>
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    {creating() ? (
                        <Title text="Create Serial Number" />
                    ) : (
                        <Title text="Serial Number Details" />
                    )}
                </Grid>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                <Fragment>
                    <SnackbarMessage
                        visible={snackbarVisible}
                        onClose={() => setSnackbarVisible(false)}
                        message="Save Successful"
                    />
                    <Grid item xs={5}>
                        <Dropdown
                            label="Transaction"
                            propertyName="transCode"
                            items={articles}
                            fullWidth
                            value={serialNumber.transCode}
                            onChange={handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={5}>
                        <InputField
                            disabled
                            fullWidth
                            label="Transaction Details"
                            value={serialNumber.transCodeDetails}
                            propertyName="transCodeDetails"
                            onChange={handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={5}>
                        <Dropdown
                            label="Article Number"
                            items={articles}
                            fullWidth
                            value={serialNumber.articleNumber}
                            propertyName="articleNumber"
                            onChange={handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={5}>
                        <InputField
                            disabled
                            fullWidth
                            label="Article Details"
                            value={serialNumber.articleDetails}
                            propertyName="articleDetails"
                            onChange={handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={5}>
                        <InputField
                            disabled
                            fullWidth
                            label="Sernos Group"
                            value={serialNumber.sernosGroup}
                            propertyName="sernosGroup"
                            onChange={handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={5}>
                        <Dropdown
                            label="Serial Numbered"
                            items={articles}
                            fullWidth
                            value={serialNumber.serialNumbered}
                            propertyName="serialNumbered"
                            onChange={handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={5}>
                        <InputField
                            fullWidth
                            label="From Serial Number"
                            value={serialNumber.fromSernosNumber}
                            propertyName="fromSernosNumber"
                            onChange={handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={5}>
                        <InputField
                            fullWidth
                            label="To Serial Number"
                            value={serialNumber.toSernosNumber}
                            propertyName="toSernosNumber"
                            onChange={handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={5}>
                        <InputField
                            fullWidth
                            label="Previous Serial Number"
                            value={serialNumber.prevSernosNumber}
                            propertyName="prevSernosNumber"
                            onChange={handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={5} />
                    <Grid item xs={5}>
                        <InputField
                            fullWidth
                            label="Document Number"
                            value={serialNumber.documentNumber}
                            propertyName="documentNumber"
                            onChange={handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={5}>
                        <InputField
                            fullWidth
                            label="Document Type"
                            value={serialNumber.documentType}
                            propertyName="documentType"
                            onChange={handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={5}>
                        <InputField
                            fullWidth
                            label="Sernos TRef"
                            value={serialNumber.sernosTRef}
                            propertyName="sernosTRef"
                            onChange={handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={5}>
                        <InputField
                            fullWidth
                            label="Sernos Date"
                            type="date"
                            value={
                                serialNumber.sernosDate
                                    ? moment(serialNumber.sernosDate).format('DD MMM YYYY')
                                    : ''
                            }
                            propertyName="sernosDate"
                            onChange={handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={8}>
                        <InputField
                            fullWidth
                            label="Notes"
                            rows={3}
                            value={serialNumber.sernosNotes}
                            propertyName="sernosNotes"
                            onChange={handleFieldChange}
                        />
                    </Grid>
                </Fragment>
            </Grid>
        </Page>
    );
}

export default SerialNumber;
