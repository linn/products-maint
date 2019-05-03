﻿import React, { Fragment, useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import { Grid } from '@material-ui/core';
import {
    SaveBackCancelButtons,
    InputField,
    Dropdown,
    Loading,
    Title,
    ErrorCard,
    SnackbarMessage
} from '@linn-it/linn-form-components-library';
import Page from '../../containers/Page';

function SerialNumberTransaction({
    loading,
    errorMessage,
    editStatus,
    item,
    itemId,
    updateSerialNumberTransaction,
    addSerialNumberTransaction,
    setEditStatus,
    snackbarVisible,
    setSnackbarVisible,
    history
}) {
    const [serialNumberTransaction, setSerialNumberTransaction] = useState({});
    const [prevSerialNumberTransaction, setPrevSerialNumberTransaction] = useState({});

    const creating = () => editStatus === 'create';
    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';

    useEffect(() => {
        if (item !== prevSerialNumberTransaction) {
            setSerialNumberTransaction(item);
            setPrevSerialNumberTransaction(item);
        }
    });

    const transCodeInvalid = () => !serialNumberTransaction.transCode;
    const descriptionInvalid = () => !serialNumberTransaction.transDescription;

    const handleSaveClick = () => {
        if (editing()) {
            updateSerialNumberTransaction(itemId, serialNumberTransaction);
            setEditStatus('view');
        } else if (creating()) {
            addSerialNumberTransaction(serialNumberTransaction);
        }
    };

    const handleCancelClick = () => {
        setSerialNumberTransaction(item);
        setEditStatus('view');
    };

    const handleBackClick = () => {
        history.push('/products/maint/serial-number-transactions');
    };

    const handleFieldChange = (propertyName, newValue) => {
        if (editStatus === 'view') {
            setEditStatus('edit');
        }

        setSerialNumberTransaction({ ...serialNumberTransaction, [propertyName]: newValue });
    };

    const yesNoOptions = ['Y', 'N'];

    return (
        <Page>
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    {creating() ? (
                        <Title text="Add Serial Number Transaction" />
                    ) : (
                        <Title text="Serial Number Transaction Details" />
                    )}
                </Grid>
                {loading || (!serialNumberTransaction && !creating()) ? (
                    <Grid item xs={12}>
                        <Loading />
                    </Grid>
                ) : (
                    <Fragment>
                        {errorMessage && (
                            <Grid item xs={12}>
                                <ErrorCard errorMessage={errorMessage} />
                            </Grid>
                        )}
                        <SnackbarMessage
                            visible={snackbarVisible}
                            onClose={() => setSnackbarVisible(false)}
                            message="Save Successful"
                        />
                        <Grid item xs={6}>
                            <InputField
                                fullWidth
                                disabled={!creating()}
                                value={serialNumberTransaction.transCode}
                                label="Trans Code"
                                helperText={
                                    !creating()
                                        ? 'This field cannot be changed'
                                        : 'This field is required'
                                }
                                onChange={handleFieldChange}
                                propertyName="transCode"
                                error={transCodeInvalid()}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <InputField
                                value={serialNumberTransaction.transDescription}
                                label="Description"
                                fullWidth
                                onChange={handleFieldChange}
                                propertyName="transDescription"
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <Dropdown
                                value={serialNumberTransaction.manualPost}
                                label="Allow manual post"
                                fullWidth
                                items={yesNoOptions}
                                onChange={handleFieldChange}
                                propertyName="manualPost"
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <SaveBackCancelButtons
                                saveDisabled={
                                    viewing() || transCodeInvalid() || descriptionInvalid()
                                }
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

SerialNumberTransaction.defaultProps = {
    item: {},
    addSerialNumberTransaction: null,
    updateSerialNumberTransaction: null,
    loading: null,
    errorMessage: '',
    itemId: null,
    snackbarVisible: false
};

SerialNumberTransaction.propTypes = {
    item: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    itemId: PropTypes.string,
    updateSerialNumberTransaction: PropTypes.func,
    addSerialNumberTransaction: PropTypes.func,
    setEditStatus: PropTypes.func.isRequired,
    loading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func.isRequired
};

export default SerialNumberTransaction;
