import React, { Fragment, useState } from 'react';
import PropTypes from 'prop-types';
import { Grid } from '@material-ui/core';
import {
    SaveBackCancelButtons,
    InputField,
    Loading,
    Title,
    ErrorCard
} from '@linn-it/linn-form-components-library';
import Page from '../containers/Page';

function VatCode({
    errorMessage,
    editStatus,
    history,
    loading,
    vatCodeId,
    addVatCode,
    setEditStatus,
    updateVatCode,
    ...props
}) {
    const [vatCode, setVatCode] = useState({});
    const [prevVatCode, setPrevVatCode] = useState(null);

    function handleSaveClick() {
        updateVatCode(vatCodeId, vatCode);
        setEditStatus('view');
    }

    function handleCancelClick() {
        setVatCode(vatCode);
        setEditStatus('view');
    }

    function handleAddClick() {
        addVatCode(vatCode);
        setEditStatus('view');
    }

    function handleBackClick() {
        history.push('/products/maint/vat-codes');
    }

    function creating() {
        return editStatus === 'create';
    }

    function editing() {
        return editStatus === 'edit';
    }

    function codeValid() {
        return !vatCode.code || vatCode.code.length === 0;
    }

    function descriptionValid() {
        return !vatCode.description;
    }

    function rateValid() {
        return typeof vatCode.rate !== 'number';
    }

    function inputValid() {
        return codeValid() || descriptionValid() || rateValid();
    }

    function handleFieldChange(propertyName, newValue) {
        setEditStatus('edit');
        setVatCode({ ...vatCode, [propertyName]: newValue });
    }

    function updateVatCodeFromProps() {
        if (props.vatCode !== prevVatCode) {
            setVatCode(props.vatCode);
            setPrevVatCode(props.vatCode);
        }
    }

    return (
        <Page>
            {!creating() && updateVatCodeFromProps()}
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
                                        : codeValid() && 'This field is required'
                                }
                                error={codeValid()}
                                onChange={handleFieldChange}
                                propertyName="code"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={vatCode.description}
                                label="Description"
                                fullWidth
                                helperText={descriptionValid() && 'This field is required'}
                                error={descriptionValid()}
                                onChange={handleFieldChange}
                                propertyName="description"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={vatCode.rate}
                                error={rateValid()}
                                label="Rate"
                                fullWidth
                                helperText={rateValid() && 'This field is required'}
                                onChange={handleFieldChange}
                                propertyName="rate"
                                type="number"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={vatCode.reason}
                                label="Reason"
                                fullWidth
                                onChange={handleFieldChange}
                                propertyName="reason"
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <SaveBackCancelButtons
                                saveDisabled={editing() || inputValid()}
                                saveClick={creating() ? handleAddClick : handleSaveClick}
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
    vatCode: PropTypes.shape({
        vatCode: PropTypes.string,
        description: PropTypes.string,
        rate: PropTypes.number,
        reason: PropTypes.string
    }),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    vatCodeId: PropTypes.string,
    updateVatCode: PropTypes.func,
    addVatCode: PropTypes.func,
    loading: PropTypes.bool,
    setEditStatus: PropTypes.func.isRequired
};

VatCode.defaultProps = {
    vatCode: {},
    addVatCode: null,
    updateVatCode: null,
    loading: null,
    errorMessage: '',
    vatCodeId: null
};

export default VatCode;
