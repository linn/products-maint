import React, { Component } from 'react';
import { Loading } from '@linn-it/linn-form-components-library';
import Grid from '@material-ui/core/Grid';
import { withStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import { ReportTable, BackButton } from '@linn-it/linn-form-components-library';
import { Link } from 'react-router-dom';

const styles = theme => ({
    root: {
        flexGrow: 1,
        paddingLeft: "20%",
        paddingRight: "20%",
    },
});

class SalesProductsByProductRange extends Component {
    
    constructor(props) {
        super(props);
    }

    handleBackClick = () => {
        const { history } = this.props;
        history.push(`/products/reports/product-ranges/report?includePhasedOut=${options.includePhasedOut}`);
    }

    render() {
        const { reportData, loading, options, classes } = this.props;
        const optionsTitle = !options.includePhasedOut || options.includePhasedOut === 'false' ? 'Live s' : 'S';
        return (
            <div className={classes.root}>
                <Grid container spacing={24} justify="center">
                    <Grid container xs={12}>
                        <Grid item xs={8}>
                            <h3>{optionsTitle}ales products for product range {options.productRangeName}</h3>
                        </Grid>
                        <Grid item xs={4}>
                            <Link style={{ display: 'block', marginTop: '20px' }} to={`/products/reports/product-ranges/report?includePhasedOut=${options.includePhasedOut}`}><Button>Back To Ranges</Button></Link>
                        </Grid>
                    </Grid>
                    <Grid item xs={12}>
                        {loading ? <Loading /> : ''}
                        <ReportTable reportData={reportData} showTotals={false} placeholderRows={10} placeholderColumns={3} showRowTitles={false} showTitle={false} />
                    </Grid>
                </Grid>
            </div>
        );
    }
}

export default withStyles(styles)(SalesProductsByProductRange);