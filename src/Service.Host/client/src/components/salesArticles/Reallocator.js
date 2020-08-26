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
    reallocate,
    history,
    snackbarVisible,
    setSnackbarVisible,
    loading,
    errorMessage,
    tariffSearchLoading,
    searchForTariff,
    clearTariffSearch,
    tariffSearchResults,
    tariffSearchErrorMessage,
    oldTariffSearchLoading,
    searchForOldTariff,
    clearOldTariffSearch,
    oldTariffSearchResults,
    OldTariffSearchErrorMessage
}) {
    const [oldTariff, setOldTariff] = useState('');
    const [newTariff, setNewTariff] = useState('');

    const submitEnabled = () => oldTariff?.length && newTariff?.length;

    const handleSubmitClick = () => {
        reallocate(oldTariff, newTariff);
    };

    const handleBackClick = () => {
        history.push('/products/maint/tariffs');
    };

    const useStyles = makeStyles(theme => ({
        bottomMargin: {
            marginBottom: theme.spacing(1)
        }
    }));

    const classes = useStyles();

    return (
        <Page>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <Title text="Reallocate products to new Tariff" />
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
                        <Grid container xs={12}>
                            <Grid item xs={4}>
                                <Grid item xs={12} className={classes.bottomMargin}>
                                    <TypeaheadDialog
                                        title="Search For Old Tariff"
                                        onSelect={newValue => {
                                            setOldTariff(newValue.tariffCode);
                                        }}
                                        searchItems={oldTariffSearchResults}
                                        loading={oldTariffSearchLoading}
                                        fetchItems={searchForOldTariff}
                                        clearSearch={() => clearOldTariffSearch}
                                    />
                                </Grid>
                                <InputField disabled value={oldTariff} label="Old Tariff" />
                            </Grid>
                            <Grid item xs={3}>
                                <Grid item xs={12} className={classes.bottomMargin}>
                                    <TypeaheadDialog
                                        title="Search For New Tariff"
                                        onSelect={newValue => {
                                            setNewTariff(newValue.tariffCode);
                                        }}
                                        searchItems={tariffSearchResults}
                                        loading={tariffSearchLoading}
                                        fetchItems={searchForTariff}
                                        clearSearch={() => clearTariffSearch}
                                    />
                                </Grid>
                                <InputField disabled value={newTariff} label="New Tariff" />
                            </Grid>
                        </Grid>
                        {tariffSearchErrorMessage && (
                            <Grid item xs={12}>
                                <ErrorCard errorMessage={errorMessage} />
                            </Grid>
                        )}
                        <Grid item xs={12}>
                            <Grid item xs={3}>
                                <Button
                                    onClick={() => handleSubmitClick()}
                                    variant="outlined"
                                    disabled={submitEnabled()}
                                >
                                    Reallocate products
                                </Button>
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
    tariffSearchResults: null,
    loading: null,
    errorMessage: '',
    snackbarVisible: false,
    tariffSearchErrorMessage: '',
    tariffSearchLoading: false
};

SalesArticleReallocator.propTypes = {
    errorMessage: PropTypes.string,
    reallocate: PropTypes.func.isRequired,
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    loading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func.isRequired,
    tariffSearchLoading: PropTypes.bool,
    searchForTariff: PropTypes.func.isRequired,
    clearTariffSearch: PropTypes.func.isRequired,
    tariffSearchResults: PropTypes.arrayOf(PropTypes.shape({})),
    tariffSearchErrorMessage: PropTypes.string
};

export default SalesArticleReallocator;
