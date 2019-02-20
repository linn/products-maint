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
    vatCode,
    vatCodeId,
    addVatCode,
    setEditStatus,
    updateVatCode
}) {
    const [vatCodeLocal, setVatCodeLocal] = useState({});
    const [prevVatCode, setPrevVatCode] = useState(null);

    function handleSaveClick() {
        updateVatCode(vatCodeId, vatCodeLocal);
        setEditStatus('view');
    }

    function handleCancelClick() {
        setVatCodeLocal(vatCodeLocal);
        setEditStatus('view');
    }

    function handleAddClick() {
        addVatCode(vatCodeLocal);
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

    function handleFieldChange(propertyName, newValue) {
        setEditStatus('edit');
        setVatCodeLocal({ ...vatCodeLocal, [propertyName]: newValue });
    }

    function updateVatCodeFromProps() {
        if (vatCode !== prevVatCode) {
            setVatCodeLocal(vatCode);
            setPrevVatCode(vatCode);
        }
    }

    return (
        <Page>
            {updateVatCodeFromProps()}
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
                {loading || !vatCodeLocal ? (
                    <Grid item xs={12}>
                        <Loading />
                    </Grid>
                ) : (
                    <Fragment>
                        <Grid item xs={8}>
                            <InputField
                                fullWidth
                                disabled={!creating()}
                                value={vatCodeLocal.code}
                                label="VAT Code"
                                helperText={
                                    !creating()
                                        ? 'This field cannot be changed'
                                        : 'This field is required'
                                }
                                onChange={handleFieldChange}
                                propertyName="code"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={vatCodeLocal.description}
                                label="Description"
                                fullWidth
                                onChange={handleFieldChange}
                                propertyName="description"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={vatCodeLocal.rate}
                                label="Rate"
                                fullWidth
                                onChange={handleFieldChange}
                                propertyName="rate"
                                type="number"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={vatCodeLocal.reason}
                                label="Reason"
                                fullWidth
                                onChange={handleFieldChange}
                                propertyName="reason"
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <SaveBackCancelButtons
                                saveDisabled={
                                    !editing() ||
                                    (!vatCodeLocal.code || vatCodeLocal.code.length === 0)
                                }
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
