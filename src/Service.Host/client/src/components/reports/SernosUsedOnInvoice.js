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
                <ErrorCard errorMessage="No Serial Numbers Found For Specified Parameters" />
            )}
        </Fragment>
    );
}

function SernosUsedOnInvoice({ reportData, loading, history }) {
    const handleBackClick = () => {
        history.push('/products/reports/sernos-used-on-invoice');
    };
    return (
        <Page>
            <Grid container spacing={24} justify="center">
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

SernosUsedOnInvoice.propTypes = {
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    reportData: PropTypes.shape({}),
    loading: PropTypes.bool
};

Report.propTypes = {
    reportData: PropTypes.shape({}),
    loading: PropTypes.bool
};

Report.defaultProps = {
    loading: false,
    reportData: {}
};

SernosUsedOnInvoice.defaultProps = {
    reportData: null,
    loading: false
};

export default SernosUsedOnInvoice;
