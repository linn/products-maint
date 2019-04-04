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
import Page from '../containers/Page';

function SernosConfig({
    loading,
    errorMessage,
    editStatus,
    item,
    itemId,
    updateSernosConfig,
    addSernosConfig,
    setEditStatus,
    snackbarVisible,
    setSnackbarVisible,
    history
}) {
    const [sernosConfig, setSernosConfig] = useState({});
    const [prevSernosConfig, setPrevSernosConfig] = useState({});

    const creating = () => editStatus === 'create';
    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';

    useEffect(() => {
        if (item !== prevSernosConfig) {
            setSernosConfig(item);
            setPrevSernosConfig(item);
        }
    });

    const nameInvalid = () => !sernosConfig.name;
    const descriptionInvalid = () => !sernosConfig.description;
    const numberOfSerialNumbersInvalid = () =>
        sernosConfig.serialNumbered === 'Y' && !sernosConfig.numberOfSernos;

    const numberOfBoxesInvalid = () =>
        sernosConfig.serialNumbered === 'Y' && sernosConfig.numberOfBoxes === null;

    const handleSaveClick = () => {
        if (editing()) {
            updateSernosConfig(itemId, sernosConfig);
            setEditStatus('view');
        } else if (creating()) {
            addSernosConfig(sernosConfig);
        }
    };

    const handleCancelClick = () => {
        setSernosConfig(item);
        setEditStatus('view');
    };

    const handleBackClick = () => {
        history.push('/products/maint/sernos-configs');
    };

    const handleFieldChange = (propertyName, newValue) => {
        if (editStatus === 'view') {
            setEditStatus('edit');
        }
        if (propertyName === 'serialNumbered') {
            setSernosConfig({
                ...sernosConfig,
                [propertyName]: newValue,
                numberOfSernos: newValue === 'N' ? 0 : sernosConfig.numberOfSernos || 0,
                numberOfBoxes: newValue === 'N' ? 0 : sernosConfig.numberOfBoxes || 0
            });
        } else {
            setSernosConfig({ ...sernosConfig, [propertyName]: newValue });
        }
    };

    const startOnOptions = ['', 'Any', 'Odd', 'Even'];
    const serialNumberedOptions = ['Y', 'N'];

    return (
        <Page>
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    {creating() ? (
                        <Title text="Add Sernos Config" />
                    ) : (
                        <Title text="Sernos Config Details" />
                    )}
                </Grid>
                {loading || (!sernosConfig && !creating()) ? (
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
                                value={sernosConfig.name}
                                label="Name"
                                helperText={
                                    !creating()
                                        ? 'This field cannot be changed'
                                        : 'This field is required'
                                }
                                onChange={handleFieldChange}
                                propertyName="name"
                                error={nameInvalid()}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <InputField
                                value={sernosConfig.description}
                                label="Description"
                                fullWidth
                                onChange={handleFieldChange}
                                propertyName="description"
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <Dropdown
                                value={sernosConfig.serialNumbered || 'N'}
                                label="Serial Numbered"
                                fullWidth
                                items={serialNumberedOptions}
                                onChange={handleFieldChange}
                                propertyName="serialNumbered"
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <InputField
                                fullWidth
                                type="number"
                                value={sernosConfig.numberOfSernos}
                                label="Number of Serial Nos"
                                onChange={handleFieldChange}
                                propertyName="numberOfSernos"
                                disabled={sernosConfig.serialNumbered === 'N'}
                                error={numberOfSerialNumbersInvalid()}
                                helperText={
                                    numberOfSerialNumbersInvalid() ? 'Must be at least 1.' : ''
                                }
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <InputField
                                fullWidth
                                type="number"
                                disabled={sernosConfig.serialNumbered === 'N'}
                                value={sernosConfig.numberOfBoxes}
                                label="Number of Serial Boxes"
                                onChange={handleFieldChange}
                                propertyName="numberOfBoxes"
                                error={numberOfBoxesInvalid()}
                                helperText={numberOfBoxesInvalid() ? 'Field Cannot Be Blank' : ''}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <Dropdown
                                value={sernosConfig.startOn}
                                label="Start On"
                                fullWidth
                                items={startOnOptions}
                                onChange={handleFieldChange}
                                propertyName="startOn"
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <SaveBackCancelButtons
                                saveDisabled={
                                    viewing() ||
                                    nameInvalid() ||
                                    descriptionInvalid() ||
                                    numberOfSerialNumbersInvalid() ||
                                    numberOfBoxesInvalid()
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

SernosConfig.defaultProps = {
    item: {},
    addSernosConfig: null,
    updateSernosConfig: null,
    loading: null,
    errorMessage: '',
    itemId: null,
    snackbarVisible: false
};

SernosConfig.propTypes = {
    item: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    itemId: PropTypes.string,
    updateSernosConfig: PropTypes.func,
    addSernosConfig: PropTypes.func,
    setEditStatus: PropTypes.func.isRequired,
    loading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func.isRequired
};

export default SernosConfig;
