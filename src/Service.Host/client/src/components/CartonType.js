﻿import React, { Fragment, useState, useEffect } from 'react';
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

function CartonType({
    loading,
    errorMessage,
    editStatus,
    item,
    itemId,
    updateCartonType,
    addCartonType,
    setEditStatus,
    snackbarVisible,
    setSnackbarVisible,
    history
}) {
    const [cartonType, setCartonType] = useState({});
    const [prevCartonType, setPrevCartonType] = useState({});

    const creating = () => editStatus === 'create';
    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';

    useEffect(() => {
        if (!creating() && item !== prevCartonType) {
            setCartonType(item);
            setPrevCartonType(item);
        }
    });

    const nameInvalid = () => !cartonType.name;
    const descriptionInvalid = () => !cartonType.description;
    const dimensionInvalid = dimension => !dimension;

    const inputInvalid = () =>
        nameInvalid() ||
        descriptionInvalid() ||
        dimensionInvalid(cartonType.height) ||
        dimensionInvalid(cartonType.width) ||
        dimensionInvalid(cartonType.depth);

    const handleSaveClick = () => {
        if (editing()) {
            updateCartonType(itemId, cartonType);
            setEditStatus('view');
        } else if (creating()) {
            addCartonType(cartonType);
        }
    };

    const handleCancelClick = () => {
        setCartonType(item);
        setEditStatus('view');
    };

    const handleBackClick = () => {
        history.push('/products/reports/carton-details/report');
    };

    const handleFieldChange = (propertyName, newValue) => {
        if (editStatus === 'view') {
            setEditStatus('edit');
        }
        setCartonType({ ...cartonType, [propertyName]: newValue });
    };

    return (
        <Page>
            <Grid container spacing={3}>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                <Grid item xs={12}>
                    {creating() ? (
                        <Title text="Create Carton Type" />
                    ) : (
                        <Title text="Carton Type Details" />
                    )}
                </Grid>
                {loading || (!cartonType && !creating()) ? (
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
                                value={cartonType.name}
                                label="Name"
                                helperText={
                                    !creating()
                                        ? 'This field cannot be changed'
                                        : 'This field is required'
                                }
                                onChange={handleFieldChange}
                                propertyName="name"
                                maxLength={10}
                                error={nameInvalid()}
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={cartonType.description}
                                label="Description"
                                fullWidth
                                onChange={handleFieldChange}
                                propertyName="description"
                                maxLength={50}
                                error={descriptionInvalid()}
                                helperText={
                                    descriptionInvalid() ? 'Description cannot be empty' : ''
                                }
                            />
                        </Grid>
                        <Grid item xs={4}>
                            <InputField
                                fullWidth
                                type="number"
                                value={cartonType.height}
                                label="Height"
                                onChange={handleFieldChange}
                                propertyName="height"
                                error={dimensionInvalid(cartonType.height)}
                                helperText={
                                    dimensionInvalid(cartonType.height)
                                        ? 'Dimension cannot be 0'
                                        : ''
                                }
                            />
                        </Grid>
                        <Grid item xs={4}>
                            <InputField
                                fullWidth
                                type="number"
                                value={cartonType.width}
                                label="Width"
                                onChange={handleFieldChange}
                                propertyName="width"
                                error={dimensionInvalid(cartonType.width)}
                                helperText={
                                    dimensionInvalid(cartonType.width)
                                        ? 'Dimension cannot be 0'
                                        : ''
                                }
                            />
                        </Grid>
                        <Grid item xs={4}>
                            <InputField
                                fullWidth
                                type="number"
                                value={cartonType.depth}
                                label="Depth"
                                onChange={handleFieldChange}
                                propertyName="depth"
                                error={dimensionInvalid(cartonType.depth)}
                                helperText={
                                    dimensionInvalid(cartonType.depth)
                                        ? 'Dimension cannot be 0'
                                        : ''
                                }
                            />
                        </Grid>
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

CartonType.defaultProps = {
    item: {},
    loading: null,
    errorMessage: '',
    itemId: null,
    updateCartonType: null,
    snackbarVisible: false,
    addCartonType: null
};

CartonType.propTypes = {
    item: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    itemId: PropTypes.string,
    updateCartonType: PropTypes.func,
    addCartonType: PropTypes.func,
    setEditStatus: PropTypes.func.isRequired,
    loading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func.isRequired
};

export default CartonType;
