import React from 'react';
import Grid from '@material-ui/core/Grid';
import { ReportTable, Loading, ErrorCard } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

export default function WeeeReport({ reportData, loading, error }) {
    return (
        <Page>
            <Grid container spacing={3}>
                {error && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={error} />
                    </Grid>
                )}
            </Grid>
            <Grid item xs={12}>
                {loading ? (
                    <Loading />
                ) : (
                    reportData && (
                        <ReportTable
                            reportData={reportData}
                            showTotals
                            showTitle
                            title={reportData.title.displayString}
                        />
                    )
                )}
            </Grid>
        </Page>
    );
}

WeeeReport.propTypes = {
    reportData: PropTypes.shape({ title: PropTypes.shape({ displayString: PropTypes.string }) }),
    loading: PropTypes.bool,
    error: PropTypes.string
};

WeeeReport.defaultProps = {
    reportData: null,
    loading: false,
    error: ''
};
