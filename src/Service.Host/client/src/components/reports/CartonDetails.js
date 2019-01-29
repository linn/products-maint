import React, { Component } from 'react';
import { Loading } from '@linn-it/linn-form-components-library';
import { Grid, Typography, Paper } from '@material-ui/core';
import { ReportTable } from '@linn-it/linn-form-components-library';
import { Link } from 'react-router-dom';
import { withStyles } from '@material-ui/core/styles';

const styles = () => ({
    root: {
        margin: 40,
        padding: 40
    }
});

class CartonDetails extends Component {
    render() {
        const { reportData, loading, classes } = this.props;

        return (
            <Paper className={classes.root}>
                <Grid container spacing={24} justify="center">
                    <Grid item xs={12}>
                        <Typography variant='h4' gutterBottom>Carton Details</Typography>
                    </Grid>
                    <Grid item xs={12}>
                        <Link style={{ display: 'block' }} to="/products/maint/carton-types/create">
                            <Typography>Create new carton type</Typography>
                        </Link>
                    </Grid>
                    <Grid item xs={12}>
                        {loading ? <Loading /> : ''}
                        <ReportTable reportData={reportData} showTotals={false} placeholderRows={10} placeholderColumns={3} showTitle={false} />
                    </Grid>
                </Grid>
            </Paper>
        );
    }
}

export default withStyles(styles)(CartonDetails);