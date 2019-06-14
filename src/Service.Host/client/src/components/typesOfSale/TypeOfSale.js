import React, { Fragment, useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import { Grid } from '@material-ui/core';
import {
    OnOffSwitch,
    SaveBackCancelButtons,
    InputField,
    Loading,
    Title,
    ErrorCard,
    SnackbarMessage
} from '@linn-it/linn-form-components-library';
import Page from '../../containers/Page';

function TypeOfSale({
    editStatus,
    errorMessage,
    history,
    itemId,
    item,
    loading,
    snackbarVisible,
    addItem,
    updateItem,
    setEditStatus,
    setSnackbarVisible
}) {
    const [typeOfSale, setTypeOfSale] = useState({});
    const [prevTypeOfSale, setPrevTypeOfSale] = useState({});

    useEffect(() => {
        if (item !== prevTypeOfSale) {
            setTypeOfSale(item);
            setPrevTypeOfSale(item);
        }
    });

    const creating = () => editStatus === 'create';
    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';

    const nameInvalid = () => !typeOfSale.name;
    const descriptionInvalid = () => !typeOfSale.description;
    const nominalInvalid = () => !typeOfSale.nominal;
    const departmentInvalid = () => !typeOfSale.department;

    const inputInvalid = () =>
        nameInvalid() || descriptionInvalid() || nominalInvalid() || departmentInvalid();

    const handleSaveClick = () => {
        setEditStatus('view');
        if (editing()) {
            updateItem(itemId, typeOfSale);
        } else if (creating()) {
            addItem(typeOfSale);
        }
    };

    const handleCancelClick = () => {
        setTypeOfSale(item);
        setEditStatus('view');
    };

    const handleBackClick = () => {
        history.push('/products/maint/types-of-sale');
    };

    const handleFieldChange = (propertyName, newValue) => {
        setEditStatus('edit');
        if (propertyName === 'realSale') {
            setTypeOfSale({ ...typeOfSale, [propertyName]: newValue ? 'Y' : 'N' });
        } else {
            setTypeOfSale({ ...typeOfSale, [propertyName]: newValue });
        }
    };

    return (
        <Page>
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    {creating() ? (
                        <Title text="Create Type of Sale" />
                    ) : (
                        <Title text="Type of Sale Details" />
                    )}
                </Grid>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                {loading || (!typeOfSale && !creating()) ? (
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
                                value={typeOfSale.name}
                                label="Name"
                                maxLength={10}
                                helperText={
                                    !creating()
                                        ? 'This field cannot be changed'
                                        : `${nameInvalid() ? 'This field is required' : ''}`
                                }
                                error={nameInvalid()}
                                onChange={handleFieldChange}
                                propertyName="name"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={typeOfSale.description}
                                label="Description"
                                fullWidth
                                maxLength={50}
                                helperText={descriptionInvalid() ? 'This field is required' : ''}
                                error={descriptionInvalid()}
                                onChange={handleFieldChange}
                                propertyName="description"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={typeOfSale.department}
                                label="Department"
                                fullWidth
                                maxLength={10}
                                helperText={departmentInvalid() ? 'This field is required' : ''}
                                error={departmentInvalid()}
                                onChange={handleFieldChange}
                                propertyName="department"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={typeOfSale.nominal}
                                label="Nominal"
                                fullWidth
                                maxLength={10}
                                helperText={nominalInvalid() ? 'This field is required' : ''}
                                error={nominalInvalid()}
                                onChange={handleFieldChange}
                                propertyName="nominal"
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <OnOffSwitch
                                label="Real Sale"
                                value={typeOfSale.realSale === 'Y'}
                                onChange={handleFieldChange}
                                propertyName="realSale"
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

TypeOfSale.propTypes = {
    item: PropTypes.shape({
        typeOfSale: PropTypes.string,
        description: PropTypes.string,
        department: PropTypes.string,
        nominal: PropTypes.string,
        realSale: PropTypes.string
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

TypeOfSale.defaultProps = {
    item: {},
    snackbarVisible: false,
    addItem: null,
    updateItem: null,
    loading: null,
    errorMessage: '',
    itemId: null
};

export default TypeOfSale;
