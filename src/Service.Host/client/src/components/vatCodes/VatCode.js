import React, { Fragment, useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import { Grid } from '@material-ui/core';
import {
    SaveBackCancelButtons,
    InputField,
    Loading,
    Title,
    ErrorCard,
    SnackbarMessage
} from '@linn-it/linn-form-components-library';
import Page from '../../containers/Page';

function VatCode({
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
    const [vatCode, setVatCode] = useState({});
    const [prevVatCode, setPrevVatCode] = useState({});

    const creating = () => editStatus === 'create';
    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';

    useEffect(() => {
        if (creating() && vatCode.vatOnly == null) {
            setVatCode({
                ...item,
                vatOnly: 'N'
            });
        } else if (item !== prevVatCode) {
            setVatCode({ ...item, reason: '' });
            setPrevVatCode(item);
        }
    });

    const codeInvalid = () => !vatCode.code;
    const descriptionInvalid = () => !vatCode.description;
    const rateInvalid = () => typeof vatCode.rate !== 'number';
    const reasonInvalid = () => !vatCode.reason && editing();

    const inputInvalid = () =>
        !creating()
            ? codeInvalid() || descriptionInvalid() || rateInvalid() || reasonInvalid()
            : codeInvalid() || descriptionInvalid() || rateInvalid();

    const handleSaveClick = () => {
        if (editing()) {
            updateItem(itemId, vatCode);
            setEditStatus('view');
        } else if (creating()) {
            addItem(vatCode);
            setEditStatus('view');
        }
    };

    const handleCancelClick = () => {
        setVatCode(prevVatCode);
        setEditStatus('view');
    };

    const handleBackClick = () => {
        history.push('/products/maint/vat-codes');
    };

    const handleFieldChange = (propertyName, newValue) => {
        setEditStatus('edit');
        setVatCode({ ...vatCode, [propertyName]: newValue });
    };

    return (
        <Page>
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    {creating() ? (
                        <Title text="Create Vat Code" />
                    ) : (
                        <Title text="Vat Code Details" />
                    )}
                </Grid>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                {loading || !vatCode ? (
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
                                disabled={!creating()}
                                value={vatCode.code}
                                label="VAT Code"
                                maxLength={1}
                                helperText={
                                    !creating()
                                        ? 'This field cannot be changed'
                                        : `${codeInvalid() ? 'This field is required' : ''}`
                                }
                                error={codeInvalid()}
                                onChange={handleFieldChange}
                                propertyName="code"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={vatCode.description}
                                label="Description"
                                maxLength={50}
                                fullWidth
                                helperText={descriptionInvalid() ? 'This field is required' : ''}
                                error={descriptionInvalid()}
                                onChange={handleFieldChange}
                                propertyName="description"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={vatCode.rate}
                                error={rateInvalid()}
                                label="Rate"
                                fullWidth
                                helperText={rateInvalid() ? 'This field is required' : ''}
                                onChange={handleFieldChange}
                                propertyName="rate"
                                type="number"
                            />
                        </Grid>
                        {!creating() && (
                            <Grid item xs={8}>
                                <InputField
                                    value={vatCode.reason}
                                    error={reasonInvalid()}
                                    label="Reason"
                                    maxLength={50}
                                    fullWidth
                                    helperText={reasonInvalid() ? 'This field is required' : ''}
                                    onChange={handleFieldChange}
                                    propertyName="reason"
                                />
                            </Grid>
                        )}
                        <Grid item xs={12}>
                            <SaveBackCancelButtons
                                saveDisabled={viewing() || inputInvalid()}
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

VatCode.propTypes = {
    item: PropTypes.shape({
        vatCode: PropTypes.string,
        description: PropTypes.string,
        rate: PropTypes.number,
        reason: PropTypes.string
    }),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    itemId: PropTypes.string,
    snackbarVisible: PropTypes.bool,
    updateItem: PropTypes.func,
    addItem: PropTypes.func,
    loading: PropTypes.bool,
    setEditStatus: PropTypes.func.isRequired,
    setSnackbarVisible: PropTypes.func.isRequired
};

VatCode.defaultProps = {
    item: {},
    addItem: null,
    snackbarVisible: false,
    updateItem: null,
    loading: null,
    errorMessage: '',
    itemId: null
};

export default VatCode;