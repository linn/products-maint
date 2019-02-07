import React, { Component } from 'react';
import Grid from '@material-ui/core/Grid';
import { ReportTable, Loading, Title, BackButton } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

class SalesProductsByProductRange extends Component {
    handleBackClick = () => {
        const { history, options } = this.props;
        history.push(
            `/products/reports/product-ranges/report?includePhasedOut=${options.includePhasedOut}`
        );
    };

    render() {
        const { reportData, loading, options } = this.props;
        const optionsTitle =
            !options.includePhasedOut || options.includePhasedOut === 'false' ? 'Live s' : 'S';
        return (
            <Page>
                <Grid container spacing={24} justify="center">
                    <Grid item xs={12}>
                        <Grid item xs={10}>
                            <Title
                                text={`${optionsTitle}ales products for product range
                                ${options.productRangeName}`}
                            />
                        </Grid>
                        <Grid item xs={2}>
                            <BackButton backClick={this.handleBackClick} />
                        </Grid>
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
    }
}

SalesProductsByProductRange.propTypes = {
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    reportData: PropTypes.shape({}),
    options: PropTypes.shape({}),
    loading: PropTypes.bool
};

SalesProductsByProductRange.defaultProps = {
    reportData: null,
    options: {},
    loading: false
};

export default SalesProductsByProductRange;
