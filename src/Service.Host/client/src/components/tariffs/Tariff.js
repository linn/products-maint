import React, { Fragment, useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { Grid, Button } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';
import PropTypes from 'prop-types';
import {
    SaveBackCancelButtons,
    InputField,
    Loading,
    Title,
    ErrorCard,
    SnackbarMessage
} from '@linn-it/linn-form-components-library';
import Page from '../../containers/Page';

function Tariff({
    updateTariff,
    setEditStatus,
    addTariff,
    item,
    history,
    itemId,
    snackbarVisible,
    setSnackbarVisible,
    editStatus,
    loading,
    errorMessage
}) {
    const [tariff, setTariff] = useState({});
    const [prevTariff, setPrevTariff] = useState({});

    const creating = () => editStatus === 'create';
    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';

    useEffect(() => {
        if (!creating() && item !== prevTariff) {
            setTariff(item);
            setPrevTariff(item);
        }
    });

    const dutyNotPercentage = () => tariff.duty < 0 || tariff.duty > 100;

    const inputInvalid = () => !tariff.tariffCode || !tariff.description || dutyNotPercentage();

    const handleSaveClick = () => {
        if (editing()) {
            updateTariff(itemId, tariff);
            setEditStatus('view');
        } else if (creating()) {
            addTariff(tariff);
        }
    };

    const handleCancelClick = () => {
        setTariff(item);
        setEditStatus('view');
    };

    const handleBackClick = () => {
        history.push('/products/maint/tariffs');
    };

    const handleFieldChange = (propertyName, newValue) => {
        setEditStatus('edit');
        setTariff({ ...tariff, [propertyName]: newValue });
    };

    const useStyles = makeStyles(theme => ({
        productsButton: {
            marginTop: theme.spacing(3)
        }
    }));

    const classes = useStyles();

    return (
        <Page>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    {creating() ? <Title text="Add Tariff" /> : <Title text="Tariff Details" />}
                </Grid>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                {loading || (!tariff && !creating()) ? (
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
                                value={tariff.tariffCode}
                                label="Tariff Code"
                                helperText={
                                    !creating()
                                        ? 'This field cannot be changed'
                                        : 'This field is required'
                                }
                                maxLength={14}
                                onChange={handleFieldChange}
                                propertyName="tariffCode"
                                error={!tariff.tariffCode}
                            />
                        </Grid>
                        <Grid item xs={4}>
                            <Button
                                component={Link}
                                to={`/products/reports/sales-articles/get-by-tariff?tariffId=${itemId}`}
                                variant="outlined"
                                className={classes.productsButton}
                            >
                                View products
                            </Button>
                        </Grid>
                        <Grid item xs={8} />
                        <Grid item xs={8}>
                            <InputField
                                value={tariff.description}
                                label="Description"
                                fullWidth
                                rows={3}
                                onChange={handleFieldChange}
                                propertyName="description"
                                maxLength={2000}
                                error={!tariff.description}
                            />
                        </Grid>
                        <Grid item xs={4} />
                        <Grid item xs={3}>
                            <InputField
                                fullWidth
                                value={tariff.usTariffCode}
                                label="US Tariff Code"
                                onChange={handleFieldChange}
                                propertyName="usTariffCode"
                                maxLength={14}
                            />
                        </Grid>
                        <Grid item xs={3}>
                            <InputField
                                fullWidth
                                type="number"
                                value={tariff.duty}
                                label="Duty"
                                adornment="%"
                                onChange={handleFieldChange}
                                maxLength={6}
                                propertyName="duty"
                                error={dutyNotPercentage()}
                                helperText={dutyNotPercentage() ? 'Must be between 0 and 100.' : ''}
                            />
                        </Grid>
                        <Grid item xs={3}>
                            <InputField
                                fullWidth
                                type="date"
                                value={tariff.dateInvalid}
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
                        </Grid>
                    </Fragment>
                )}
            </Grid>
        </Page>
    );
}

Tariff.defaultProps = {
    item: {},
    addTariff: null,
    updateTariff: null,
    loading: null,
    errorMessage: '',
    itemId: null,
    snackbarVisible: false
};

Tariff.propTypes = {
    item: PropTypes.shape({}),
    editStatus: PropTypes.string.isRequired,
    setEditStatus: PropTypes.func.isRequired,
    errorMessage: PropTypes.string,
    itemId: PropTypes.string,
    updateTariff: PropTypes.func,
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    addTariff: PropTypes.func,
    loading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func.isRequired
};

export default Tariff;
