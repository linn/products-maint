import React, { Fragment } from 'react';
import { Grid } from '@material-ui/core';
import {
    ReportTable,
    Loading,
    Title,
    BackButton,
    ErrorCard
} from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

function Report({ reportData, loading }) {
    if (loading) {
        return <Loading />;
    }
    return (
        <Fragment>
            {reportData && reportData.results.length > 0 ? (
                <ReportTable
                    showRowTitles={false}
                    reportData={reportData}
                    showTotals={false}
                    title={reportData ? reportData.title.displayString : null}
                    showTitle={false}
                />
            ) : (
                <ErrorCard errorMessage="No Sales Articles Found For Specified Tariff" />
            )}
        </Fragment>
    );
}

function SalesArticlesByTariff({ reportData, loading, history, errorMessage }) {
    const handleBackClick = () => {
        history.push('/products/maint/tariffs');
    };
    return (
        <Page>
            <Grid container spacing={3} justify="center">
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                <Grid item xs={12}>
                    <Grid item xs={10}>
                        <Title
                            text={
                                loading || !reportData ? 'Loading' : reportData.title.displayString
                            }
                        />
                    </Grid>
                </Grid>
                <Grid item xs={12}>
                    <Report reportData={reportData} loading={loading} />
                </Grid>
                <Grid item xs={12}>
                    <BackButton backClick={handleBackClick} />
                </Grid>
            </Grid>
        </Page>
    );
}

SalesArticlesByTariff.propTypes = {
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    reportData: PropTypes.shape({}),
    loading: PropTypes.bool,
    errorMessage: PropTypes.string
};

Report.propTypes = {
    reportData: PropTypes.shape({}),
    loading: PropTypes.bool
};

Report.defaultProps = {
    loading: false,
    reportData: {}
};

SalesArticlesByTariff.defaultProps = {
    reportData: null,
    loading: false,
    errorMessage: ''
};

export default SalesArticlesByTariff;
