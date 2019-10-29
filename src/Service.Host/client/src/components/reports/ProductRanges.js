import React from 'react';
import { Loading, ReportTable, Title, ErrorCard } from '@linn-it/linn-form-components-library';
import Grid from '@material-ui/core/Grid';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

const ProductRanges = ({ reportData, loading, options, errorMessage }) => {
    const optionsTitle =
        !options.includePhasedOut || options.includePhasedOut === 'false' ? 'Live ' : '';
    return (
        <Page>
            <Grid container spacing={3} justify="center">
                <Grid item xs={12}>
                    <Title text={`${optionsTitle} Product Ranges`} />
                </Grid>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                <Grid item xs={12}>
                    {loading ? <Loading /> : ''}
                    {reportData && reportData.results.length > 0 && (
                        <ReportTable
                            reportData={reportData}
                            showTotals={false}
                            placeholderRows={10}
                            placeholderColumns={3}
                            showRowTitles={false}
                            showTitle={false}
                        />
                    )}
                </Grid>
            </Grid>
        </Page>
    );
};

ProductRanges.propTypes = {
    reportData: PropTypes.shape({}),
    loading: PropTypes.bool,
    options: PropTypes.shape({}),
    errorMessage: PropTypes.string
};

ProductRanges.defaultProps = {
    reportData: null,
    options: {},
    loading: false,
    errorMessage: ''
};

export default ProductRanges;
