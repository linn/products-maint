import React from 'react';
import { Grid } from '@material-ui/core';
import {
    ReportTable,
    Loading,
    Title,
    ExportButton,
    ErrorCard
} from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

const OrdersByNominal = ({ reportData, loading, config, errorMessage }) => {
    //const href = `${config.appRoot}/products/reports/orders-by-nominal/export`;

    return (
        <Page>
            <Grid container spacing={3} justify="center">
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                <Grid item xs={8}>
                    <Title text="Orders By Nominal" /> {/*// todo: custom title */}
                </Grid>
                {/* <Grid item xs={4}>
                    <ExportButton href={href} />
                </Grid> */}
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

OrdersByNominal.propTypes = {
    reportData: PropTypes.shape({}),
    config: PropTypes.shape({}),
    loading: PropTypes.bool,
    errorMessage: PropTypes.string
};

OrdersByNominal.defaultProps = {
    reportData: null,
    config: {},
    loading: false,
    errorMessage: ''
};

export default OrdersByNominal;
