import React, { Component } from 'react';
import { Loading, ReportTable } from '@linn-it/linn-form-components-library';
import Grid from '@material-ui/core/Grid';
import { withStyles } from '@material-ui/core/styles';
import PropTypes from 'prop-types';

const styles = () => ({
    root: {
        paddingLeft: '20%',
        paddingRight: '20%'
    }
});

class ProductRanges extends Component {
    render() {
        const { reportData, loading, options, classes } = this.props;
        const optionsTitle = !options.includePhasedOut || options.includePhasedOut === 'false' ? 'Live ' : '';
        return (
            <div className={classes.root}>
                <Grid container spacing={24} justify="center">
                    <Grid item xs={12}>
                        <h3>{optionsTitle}Product Ranges</h3>
                    </Grid>
                    <Grid item xs={12}>
                        {loading ? <Loading /> : ''}
                        <ReportTable
                            reportData={reportData}
                            showTotals={false} placeholderRows={10} 
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

ProductRanges.propTypes = {
    reportData: PropTypes.shape({}),
    classes: PropTypes.shape({}),
    loading: PropTypes.bool
};

ProductRanges.defaultProps = {
    reportData: null,
    classes: {},
    loading: false
};

export default withStyles(styles)(ProductRanges);
