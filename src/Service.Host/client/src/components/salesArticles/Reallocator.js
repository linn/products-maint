import React, { useState } from 'react';
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
    item,
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
    oldTariffSearchErrorMessage
}) {
    const [oldTariff, setOldTariff] = useState({});
    const [newTariff, setNewTariff] = useState({});

    const submitEnabled = () =>
        !(typeof oldTariff?.id !== 'undefined' && typeof newTariff?.id !== 'undefined');

    const handleSubmitClick = () => {
        reallocate({
            oldTariffId: parseInt(oldTariff.id, 10),
            newTariffId: parseInt(newTariff.id, 10)
        });
    };

    const handleBackClick = () => {
        history.push('/products/maint/tariffs');
    };

    const useStyles = makeStyles(theme => ({
        marginTop: {
            marginTop: theme.spacing(3)
        },
        marginLeft: {
            marginLeft: theme.spacing(12)
        }
    }));

    const classes = useStyles();

    return (
        <Page>
            <Grid container>
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
                        <Grid item xs={12}>
                            <SnackbarMessage
                                visible={snackbarVisible}
                                onClose={() => setSnackbarVisible(false)}
                                message={`${item && item.count} products reallocated!`}
                            />
                        </Grid>
                        <Grid item xs={2}>
                            <InputField disabled value={oldTariff.tariffCode} label="Old Tariff" />
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
                        <Grid item xs={2} className={classes.marginTop}>
                            <Button
                                href={`/products/reports/sales-articles/get-by-tariff?tariffId=${oldTariff.id}`}
                                variant="outlined"
                                disabled={!(typeof oldTariff?.id !== 'undefined')}
                                target="_blank"
                            >
                                View products
                            </Button>
                        </Grid>
                        <Grid item xs={2}>
                            <InputField disabled value={newTariff.tariffCode} label="New Tariff" />
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
                        <Grid item xs={2} className={classes.marginTop}>
                            <Button
                                href={`/products/reports/sales-articles/get-by-tariff?tariffId=${newTariff.id}`}
                                variant="outlined"
                                disabled={!(typeof newTariff?.id !== 'undefined')}
                                target="_blank"
                            >
                                View products
                            </Button>
                        </Grid>
                        {tariffSearchErrorMessage && (
                            <Grid item xs={12}>
                                <ErrorCard errorMessage={errorMessage} />
                            </Grid>
                        )}
                        {oldTariffSearchErrorMessage && (
                            <Grid item xs={12}>
                                <ErrorCard errorMessage={errorMessage} />
                            </Grid>
                        )}
                        <Grid item xs={12} className={classes.marginTop}>
                            <Grid item xs={3} className={classes.marginLeft}>
                                <Button
                                    onClick={() => handleSubmitClick()}
                                    variant="outlined"
                                    disabled={submitEnabled()}
                                >
                                    Reallocate products
                                </Button>
                            </Grid>
                        </Grid>
                        <Grid item xs={12} className={classes.marginTop}>
                            <BackButton backClick={handleBackClick} />
                        </Grid>
                    </>
                )}
            </Grid>
        </Page>
    );
}

SalesArticleReallocator.defaultProps = {
    loading: null,
    errorMessage: '',
    snackbarVisible: false,
    tariffSearchErrorMessage: '',
    tariffSearchLoading: false,
    tariffSearchResults: [{}],
    oldTariffSearchLoading: false,
    oldTariffSearchResults: [{}],
    oldTariffSearchErrorMessage: '',
    item: { count: 0 }
};

SalesArticleReallocator.propTypes = {
    item: PropTypes.shape({ count: PropTypes.string }),
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
    tariffSearchErrorMessage: PropTypes.string,
    oldTariffSearchLoading: PropTypes.bool,
    searchForOldTariff: PropTypes.func.isRequired,
    clearOldTariffSearch: PropTypes.func.isRequired,
    oldTariffSearchResults: PropTypes.arrayOf(PropTypes.shape({})),
    oldTariffSearchErrorMessage: PropTypes.string
};

export default SalesArticleReallocator;
