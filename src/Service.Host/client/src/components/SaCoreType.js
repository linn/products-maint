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
import Page from '../containers/Page';

function SaCoreType({
    loading,
    errorMessage,
    editStatus,
    item,
    saCoreTypeId,
    updateSaCoreType,
    addSaCoreType,
    setEditStatus,
    snackbarVisible,
    setSnackbarVisible,
    history
}) {
    const [saCoreType, setSaCoreType] = useState({});
    const [prevSaCoreType, setPrevSaCoreType] = useState({});

    const creating = () => editStatus === 'create';
    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';

    useEffect(() => {
        if (!creating() && item !== prevSaCoreType) {
            setSaCoreType(item);
            setPrevSaCoreType(item);
        }
    });

    const inputInvalid = () => !saCoreType.coreType;

    const handleSaveClick = () => {
        if (editing()) {
            updateSaCoreType(saCoreTypeId, saCoreType);
            setEditStatus('view');
        } else if (creating()) {
            addSaCoreType(saCoreType);
            history.push(`/products/maint/sa-core-types/${saCoreType.coreType}`);
        }
    };

    const handleCancelClick = () => {
        setSaCoreType(item);
        setEditStatus('view');
    };

    const handleBackClick = () => {
        history.push('/products/maint/sa-core-types');
    };

    const handleFieldChange = (propertyName, newValue) => {
        setEditStatus('edit');
        setSaCoreType({ ...saCoreType, [propertyName]: newValue });
    };

    return (
        <Page>
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    {creating() ? (
                        <Title text="Add Sales Article Core Type" />
                    ) : (
                        <Title text="Sales Article Core Type Details" />
                    )}
                </Grid>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                {loading || !saCoreType ? (
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
                        <Grid item xs={4}>
                            <InputField
                                fullWidth
                                disabled={!creating()}
                                value={saCoreType.coreType}
                                label="Core Type"
                                helperText={
                                    !creating()
                                        ? 'This field cannot be changed'
                                        : 'This field is required'
                                }
                                onChange={handleFieldChange}
                                propertyName="coreType"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={saCoreType.description}
                                label="Description"
                                fullWidth
                                onChange={handleFieldChange}
                                propertyName="description"
                            />
                        </Grid>
                        <Grid item xs={3}>
                            <InputField
                                fullWidth
                                type="number"
                                value={saCoreType.lookAheadDays}
                                label="Look Ahead Days"
                                onChange={handleFieldChange}
                                propertyName="lookAheadDays"
                            />
                        </Grid>
                        <Grid item xs={3}>
                            <InputField
                                fullWidth
                                type="number"
                                value={saCoreType.triggerLevel}
                                label="Trigger level"
                                onChange={handleFieldChange}
                                propertyName="triggerLevel"
                            />
                        </Grid>
                        <Grid item xs={3}>
                            <InputField
                                fullWidth
                                type="number"
                                value={saCoreType.sortOrder}
                                label="Sort Order"
                                onChange={handleFieldChange}
                                propertyName="sortOrder"
                            />
                        </Grid>
                        <Grid item xs={3}>
                            <InputField
                                fullWidth
                                type="date"
                                value={saCoreType.dateInvalid}
                                label="Date Invalid"
                                onChange={handleFieldChange}
                                propertyName="dateInvalid"
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <SaveBackCancelButtons
                                saveDisabled={viewing() || inputInvalid()}
                                saveClick={handleSaveClick}
                                cancelClick={handleCancelClick}
                                backClick={handleBackClick}
                            />
                        </Grid>{' '}
                    </Fragment>
                )}
            </Grid>
        </Page>
    );
}

SaCoreType.defaultProps = {
    item: {},
    addSaCoreType: null,
    updateSaCoreType: null,
    loading: null,
    errorMessage: '',
    saCoreTypeId: null
};

SaCoreType.propTypes = {
    item: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    saCoreTypeId: PropTypes.string,
    updateSaCoreType: PropTypes.func,
    addSaCoreType: PropTypes.func,
    setEditStatus: PropTypes.func,
    loading: PropTypes.bool
};

export default SaCoreType;
