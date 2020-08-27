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
    snackbarText,
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
    const [oldTariff, setOldTariff] = useState({});
    const [newTariff, setNewTariff] = useState({});

    const submitEnabled = () =>
        !(typeof oldTariff?.id !== 'undefined' && typeof newTariff?.id !== 'undefined');

    const handleSubmitClick = () => {
        reallocate({ oldTariffId: `${oldTariff.id}`, newTariffId: `${newTariff.id}` });
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
                            message={'products reallocated!'}
                        />
                        <Grid container spacing={3}>
                            <Grid item xs={4}>
                                <Grid item xs={12} className={classes.bottomMargin}>
                                    <TypeaheadDialog
                                        title="Search For Old Tariff"
                                        onSelect={newValue => {
                                            setOldTariff(newValue);
                                        }}
                                        searchItems={oldTariffSearchResults}
                                        loading={oldTariffSearchLoading}
                                        fetchItems={searchForOldTariff}
                                        clearSearch={() => clearOldTariffSearch}
                                    />
                                </Grid>
                                <InputField
                                    disabled
                                    value={oldTariff.tariffCode}
                                    label="Old Tariff"
                                />
                                <Button
                                    href={`/products/reports/sales-articles/get-by-tariff?tariffId=${newTariff.id}`}
                                    variant="outlined"
                                    disabled={!(typeof newTariff?.id !== 'undefined')}
                                    target="_blank"
                                >
                                    View products
                                </Button>
                            </Grid>
                            <Grid item xs={3}>
                                <Grid item xs={12} className={classes.bottomMargin}>
                                    <TypeaheadDialog
                                        title="Search For New Tariff"
                                        onSelect={newValue => {
                                            setNewTariff(newValue);
                                        }}
                                        searchItems={tariffSearchResults}
                                        loading={tariffSearchLoading}
                                        fetchItems={searchForTariff}
                                        clearSearch={() => clearTariffSearch}
                                    />
                                </Grid>
                                <InputField
                                    disabled
                                    value={newTariff.tariffCode}
                                    label="New Tariff"
                                />

                                <Button
                                    href={`/products/reports/sales-articles/get-by-tariff?tariffId=${newTariff.id}`}
                                    variant="outlined"
                                    disabled={!(typeof newTariff?.id !== 'undefined')}
                                    target="_blank"
                                >
                                    View products
                                </Button>
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
