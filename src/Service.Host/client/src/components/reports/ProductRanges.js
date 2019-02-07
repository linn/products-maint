import React from 'react';
import { Loading, ReportTable, Title } from '@linn-it/linn-form-components-library';
import Grid from '@material-ui/core/Grid';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

const ProductRanges = ({ reportData, loading, options }) => {
    const optionsTitle =
        !options.includePhasedOut || options.includePhasedOut === 'false' ? 'Live ' : '';
    return (
        <Page>
            <Grid container spacing={24} justify="center">
                <Grid item xs={12}>
                    <Title text={`${optionsTitle} Product Ranges`} />
                </Grid>
                <Grid item xs={12}>
                    {loading ? <Loading /> : ''}
                    <ReportTable
                        reportData={reportData}
                        showTotals={false}
                        placeholderRows={10}
                        placeholderColumns={3}
                        showRowTitles={false}
                        showTitle={false}
                    />
                </Grid>
            </Grid>
        </Page>
    );
};

ProductRanges.propTypes = {
    reportData: PropTypes.shape({}),
    loading: PropTypes.bool,
    options: PropTypes.shape({})
};

ProductRanges.defaultProps = {
    reportData: null,
    options: {},
    loading: false
};

export default ProductRanges;
