import React, { Component } from 'react';
import { Loading } from '@linn-it/linn-form-components-library';
import Grid from '@material-ui/core/Grid';
import { ReportTable } from '@linn-it/linn-form-components-library';
import { Link } from 'react-router-dom';
import { withStyles } from '@material-ui/core/styles';

const styles = theme => ({
    root: {
        flexGrow: 1,
        paddingLeft: "20%",
        paddingRight: "20%",
    },
});

class CartonDetails extends Component {
    render() {
        const { reportData, loading, classes } = this.props;

        return (
            <div className={classes.root}>
                <Grid container spacing={24} justify="center">
                    <Grid item xs={12}>
                        <h3>Carton Details</h3>
                    </Grid>
                    <Grid item xs={12}>
                        <Link style={{ display: 'block' }} to="/products/maint/carton-types/create">Create new carton type</Link>
                    </Grid>
                    <Grid item xs={12}>
                        {loading ? <Loading /> : ''}
                        <ReportTable reportData={reportData} showTotals={false} placeholderRows={10} placeholderColumns={3} showTitle={false} />
                    </Grid>
                </Grid>
            </div>
        );
    }
}

export default withStyles(styles)(CartonDetails);