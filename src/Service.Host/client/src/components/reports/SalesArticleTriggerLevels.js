import React, { Fragment } from 'react';
import { Grid } from '@material-ui/core';
import { ReportTable, Loading, Title, ErrorCard } from '@linn-it/linn-form-components-library';
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
                    showRowTitles
                    reportData={reportData}
                    showTotals={false}
                    title={reportData.title.displayString}
                    showTitle={false}
                />
            ) : (
                <ErrorCard errorMessage="No Sales Articles Trigger Levels" />
            )}
        </Fragment>
    );
}

function SalesArticleTriggerLevels({ reportData, loading, errorMessage }) {
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
            </Grid>
        </Page>
    );
}

SalesArticleTriggerLevels.propTypes = {
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

SalesArticleTriggerLevels.defaultProps = {
    reportData: null,
    loading: false,
    errorMessage: ''
};

export default SalesArticleTriggerLevels;
