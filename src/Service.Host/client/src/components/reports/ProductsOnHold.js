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
                    reportData={reportData}
                    showTotals={false}
                    showRowTitles={true}
                    title={reportData ? reportData.title.displayString : null}
                    showTitle={false}
                />
            ) : (
                <ErrorCard errorMessage="No Products On Hold" />
            )}
        </Fragment>
    );
}

function ProductsOnHold({ reportData, loading, history }) {
    const handleBackClick = () => {
        history.push('/products/maint');
    };

    return (
        <Page>
            <Grid container spacing={24} justify="center">
                <Grid item xs={12}>
                    <Grid item xs={10}>
                        <Title text="Products On Hold" />
                    </Grid>
                    <Grid item xs={2}>
                        <BackButton backClick={handleBackClick} />
                    </Grid>
                </Grid>
                <Grid item xs={12}>
                    <Report reportData={reportData} loading={loading} />
                </Grid>
            </Grid>
        </Page>
    );
}

ProductsOnHold.propTypes = {
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    reportData: PropTypes.shape({}),
    loading: PropTypes.bool
};

Report.propTypes = {
    reportData: PropTypes.shape({}).isRequired,
    loading: PropTypes.bool
};

Report.defaultProps = {
    loading: false
};

ProductsOnHold.defaultProps = {
    reportData: null,
    loading: false
};

export default ProductsOnHold;
