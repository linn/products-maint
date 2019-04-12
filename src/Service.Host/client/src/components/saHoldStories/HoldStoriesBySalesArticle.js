import React, { Fragment } from 'react';
import { Grid } from '@material-ui/core';
import { ReportTable, Loading, Title, ErrorCard } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';

function Report({ reportData, loading }) {
    if (loading) {
        return <Loading />;
    }
    return (
        <Fragment>
            {reportData && reportData.results.length > 0 ? (
                <ReportTable
                    reportData={reportData}
                    showTotals={false}
                    showRowTitles
                    title={reportData ? reportData.title.displayString : null}
                    showTitle={false}
                />
            ) : (
                <ErrorCard errorMessage="No Hold History Found" />
            )}
        </Fragment>
    );
}

function HoldStoriesBySalesArticle({ reportData, loading, match }) {
    const titleify = articleNumber => articleNumber.replace(/%2F/g, '/');

    return (
        <Grid container spacing={24} justify="center">
            <Grid item xs={12}>
                <Grid item xs={10}>
                    <Title text={`${titleify(match.params.articleNumber)} Hold Stories`} />
                </Grid>
            </Grid>
            <Grid item xs={12}>
                <Report reportData={reportData} loading={loading} />
            </Grid>
        </Grid>
    );
}

HoldStoriesBySalesArticle.propTypes = {
    reportData: PropTypes.shape({}),
    options: PropTypes.shape({}),
    match: PropTypes.shape({}).isRequired,
    loading: PropTypes.bool
};

Report.propTypes = {
    reportData: PropTypes.shape({}),
    loading: PropTypes.bool
};

Report.defaultProps = {
    loading: false,
    reportData: null
};

HoldStoriesBySalesArticle.defaultProps = {
    reportData: null,
    options: {},
    loading: false
};

export default HoldStoriesBySalesArticle;
