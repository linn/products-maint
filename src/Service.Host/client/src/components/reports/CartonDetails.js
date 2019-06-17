import React from 'react';
import { ReportTable, Loading, CreateButton, Title } from '@linn-it/linn-form-components-library';
import { Grid } from '@material-ui/core';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

const CartonDetails = ({ reportData, loading }) => (
    <Page>
        <Grid container spacing={3} justify="center">
            <Grid item xs={12}>
                <Title text="Carton Details" />
                <CreateButton createUrl="/products/maint/carton-types/create" />
            </Grid>
            <Grid item xs={12}>
                {loading && <Loading />}
                <ReportTable
                    reportData={reportData}
                    showTotals={false}
                    showRowTitles
                    placeholderRows={10}
                    placeholderColumns={3}
                    showTitle={false}
                />
            </Grid>
        </Grid>
    </Page>
);

CartonDetails.propTypes = {
    reportData: PropTypes.shape({}),
    loading: PropTypes.bool
};

CartonDetails.defaultProps = {
    reportData: null,
    loading: false
};

export default CartonDetails;
