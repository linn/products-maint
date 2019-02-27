import React from 'react';
import { Grid } from '@material-ui/core';
import { ReportTable, ExportButton, Loading, Title } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

const EanCodes = ({ reportData, loading, options, config }) => {
    const optionsTitle =
        options.cartonisedOnly && options.cartonisedOnly !== 'false'
            ? '(Cartonised products only)'
            : '';
    const href = `${
        config.appRoot
    }/products/reports/sales-article-ean-codes/export?includePhasedOut=${
        options.includePhasedOut
    }&cartonisedOnly=${options.cartonisedOnly}`;

    return (
        <Page>
            <Grid container spacing={24} justify="center">
                <Grid item xs={9}>
                    <Title text={` Sales Article Ean Codes ${optionsTitle}`} />
                </Grid>
                <Grid item xs={3}>
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

EanCodes.propTypes = {
    reportData: PropTypes.shape({}),
    options: PropTypes.shape({}),
    config: PropTypes.shape({}),
    loading: PropTypes.bool
};

EanCodes.defaultProps = {
    reportData: null,
    options: {},
    config: {},
    loading: false
};

export default EanCodes;
