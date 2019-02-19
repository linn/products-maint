import React from 'react';
import { Grid } from '@material-ui/core';
import { ReportTable, Loading, Title, ExportButton } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

const SalesArticleCoreTypes = ({ reportData, loading, options, config }) => {
    const href = `${config.appRoot}/products/reports/sales-article-core-types/export`;

    return (
        <Page>
            <Grid container spacing={24} justify="center">
                <Grid item xs={8}>
                    <Title text='Sales Article Core Types' />
                </Grid>
                <Grid item xs={4}>
                    <ExportButton href={href} />
                </Grid>
                <Grid item xs={12}>
                    {loading ? <Loading /> : ''}
                    <ReportTable
                        reportData={reportData}
                        showTotals={false}
                        placeholderRows={10}
                        placeholderColumns={3}
                        showTitle={false}
                    />
                </Grid>
            </Grid>
        </Page>
    );
};

SalesArticleCoreTypes.propTypes = {
    reportData: PropTypes.shape({}),
    options: PropTypes.shape({}),
    config: PropTypes.shape({}),
    loading: PropTypes.bool
};

SalesArticleCoreTypes.defaultProps = {
    reportData: null,
    options: {},
    config: {},
    loading: false
};

export default SalesArticleCoreTypes;
