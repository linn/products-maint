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

function CartonType({
    initialise,
    loading,
    errorMessage,
    editStatus,
    item,
    cartonTypeId,
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

    useEffect(() => {
        if (!creating()) {
            initialise({ cartonTypeId });
        }
    }, [cartonTypeId]);

    // useEffect(() => {
    //     alert('I was called');
    // }, [addCartonType]);

    const nameInvalid = () => !cartonType.name;
    const dimensionInvalid = dimension => !dimension;

    const inputInvalid = () =>
        nameInvalid() ||
        dimensionInvalid(cartonType.height) ||
        dimensionInvalid(cartonType.width) ||
        dimensionInvalid(cartonType.depth);

    const handleSaveClick = () => {
        if (editing()) {
            updateCartonType(cartonTypeId, cartonType);
            setEditStatus('view');
        } else if (creating()) {
            addCartonType(cartonType);
            if (!errorMessage) {
                history.push(`/products/maint/carton-types/${cartonType.name}`);
            }
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
        setEditStatus('edit');
        setCartonType({ ...cartonType, [propertyName]: newValue });
    };
    return (
        <Page>
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    {creating() ? (
                        <Title text="Create Carton Type" />
                    ) : (
                        <Title text="Carton Type Details" />
                    )}
                </Grid>
                {(loading || !cartonType) && !creating() ? (
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
    initialise: null,
    loading: null,
    errorMessage: '',
    cartonTypeId: null,
    updateCartonType: null,
    snackbarVisible: false,
    addCartonType: null
};

CartonType.propTypes = {
    initialise: PropTypes.func,
    item: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    cartonTypeId: PropTypes.string,
    updateCartonType: PropTypes.func,
    addCartonType: PropTypes.func,
    setEditStatus: PropTypes.func.isRequired,
    loading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func.isRequired
};

export default CartonType;
