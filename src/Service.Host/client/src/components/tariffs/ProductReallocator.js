import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Grid, Button } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';
import PropTypes from 'prop-types';
import {
    InputField,
    Loading,
    Title,
    ErrorCard,
    SnackbarMessage,
    BackButton,
    TypeaheadDialog
} from '@linn-it/linn-form-components-library';
import Page from '../../containers/Page';

function SalesArticleReallocator({
    reallocateSalesArticles,
    history,
    snackbarVisible,
    setSnackbarVisible,
    loading,
    errorMessage,
    oldTariffSearchLoading,
    searchForOldTariff,
    clearOldTariffSearch,
    oldTariffSearchResults,
    newTariffSearchLoading,
    searchForNewTariff,
    clearNewTariffSearch,
    newTariffSearchResults
}) {
    const [oldTariff, setOldTariff] = useState({});
    const [newTariff, setNewTariff] = useState({});

    const submitEnabled = () => oldTariff() && newTariff();

    const handleSubmitClick = () => {
        reallocateSalesArticles(oldTariff(), newTariff());
    };

    const handleBackClick = () => {
        history.push('/products/maint/tariffs');
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
                    <Title text="Reallocate all products from old tariff to new" />
                </Grid>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                {loading ? (
                    <Grid item xs={12}>
                        <Loading />
                    </Grid>
                ) : (
                    <>
                        <SnackbarMessage
                            visible={snackbarVisible}
                            onClose={() => setSnackbarVisible(false)}
                            message="Save Successful"
                        />
                        <Grid item xs={12}>
                            <Grid item xs={4}>
                                <TypeaheadDialog
                                    title="Search For Old Tariff"
                                    onSelect={newValue => {
                                        setOldTariff(newValue.tariffCode);
                                    }}
                                    searchItems={oldTariffSearchResults.map(w => ({
                                        code: w.tariffCode,
                                        description: w.description
                                    }))}
                                    loading={oldTariffSearchLoading}
                                    fetchItems={searchForOldTariff}
                                    clearSearch={clearOldTariffSearch}
                                />
                            </Grid>
                            <Grid item xs={4}>
                                <TypeaheadDialog
                                    title="Search For New Tariff"
                                    onSelect={newValue => {
                                        setNewTariff(newValue.tariffCode);
                                    }}
                                    searchItems={newTariffSearchResults.map(w => ({
                                        code: w.tariffCode,
                                        description: w.description
                                    }))}
                                    loading={newTariffSearchLoading}
                                    fetchItems={searchForNewTariff}
                                    clearSearch={clearNewTariffSearch}
                                />
                            </Grid>
                        </Grid>
                        <Grid item xs={12}>
                            <Grid item xs={4}>
                                <InputField disabled value={oldTariff()} label="Old Tariff" />
                            </Grid>
                            <Grid item xs={4}>
                                <Button
                                    component={Link}
                                    onClick={handleSubmitClick()}
                                    variant="outlined"
                                    className={classes.productsButton}
                                    disabled={submitEnabled()}
                                >
                                    Reallocate products to:
                                </Button>
                            </Grid>
                            <Grid item xs={4}>
                                <InputField disabled value={newTariff()} label="New Tariff" />
                            </Grid>
                        </Grid>
                        <Grid item xs={12}>
                            <BackButton backClick={handleBackClick} />
                        </Grid>
                    </>
                )}
            </Grid>
        </Page>
    );
}

SalesArticleReallocator.defaultProps = {
    oldTariffSearchResults: null,
    newTariffSearchResults: null,
    loading: null,
    errorMessage: '',
    snackbarVisible: false
};

SalesArticleReallocator.propTypes = {
    errorMessage: PropTypes.string,
    reallocateSalesArticles: PropTypes.func.isRequired,
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    loading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func.isRequired,
    oldTariffSearchLoading: PropTypes.bool.isRequired,
    searchForOldTariff: PropTypes.func.isRequired,
    clearOldTariffSearch: PropTypes.func.isRequired,
    oldTariffSearchResults: PropTypes.arrayOf(PropTypes.shape({})),
    newTariffSearchLoading: PropTypes.bool.isRequired,
    searchForNewTariff: PropTypes.func.isRequired,
    clearNewTariffSearch: PropTypes.func.isRequired,
    newTariffSearchResults: PropTypes.arrayOf(PropTypes.shape({}))
};

export default SalesArticleReallocator;
