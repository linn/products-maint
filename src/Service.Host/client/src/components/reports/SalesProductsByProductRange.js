import React, { Component } from 'react';
import Grid from '@material-ui/core/Grid';
import { withStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import { ReportTable, Loading } from '@linn-it/linn-form-components-library';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';

const styles = () => ({
    root: {
        paddingLeft: '20%',
        paddingRight: '20%'
    }
});

class SalesProductsByProductRange extends Component {
    handleBackClick = () => {
        const { history, options } = this.props;
        history.push(
            `/products/reports/product-ranges/report?includePhasedOut=${options.includePhasedOut}`
        );
    };

    render() {
        const { reportData, loading, options, classes } = this.props;
        const optionsTitle =
            !options.includePhasedOut || options.includePhasedOut === 'false' ? 'Live s' : 'S';
        return (
            <div className={classes.root}>
                <Grid container spacing={24} justify="center">
                    <Grid item xs={12}>
                        <Grid item xs={8}>
                            <h3>
                                {optionsTitle}ales products for product range{' '}
                                {options.productRangeName}
                            </h3>
                        </Grid>
                        <Grid item xs={4}>
                            <Link
                                style={{ display: 'block', marginTop: '20px' }}
                                to={`/products/reports/product-ranges/report?includePhasedOut=${
                                    options.includePhasedOut
                                }`}
                            >
                                <Button>Back To Ranges</Button>
                            </Link>
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
            </div>
        );
    }
}

SalesProductsByProductRange.propTypes = {
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    reportData: PropTypes.shape({}),
    options: PropTypes.shape({}),
    classes: PropTypes.shape({}),
    loading: PropTypes.bool
};

SalesProductsByProductRange.defaultProps = {
    reportData: null,
    classes: {},
    options: {},
    loading: false
};

export default withStyles(styles)(SalesProductsByProductRange);
