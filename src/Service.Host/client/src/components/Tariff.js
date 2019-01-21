import React, { Component } from 'react';
import { Button, Grid, Paper, Typography } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import { Link } from 'react-router-dom';
import { Loading } from './common/Loading';
import { getSelfHref } from '../helpers/utilities';

const styles = theme => ({
    paper: {
        padding: theme.spacing.unit * 6
    },
    boldHeader: {
        fontWeight: 'bold',
        width: '140px'
    },
    pullRight: {
        float: 'right'
    },
    biggerText: {
        fontSize: 14
    }
});

class Tariff extends Component {

    render() {
        const { tariff, loading, classes } = this.props;

        if (loading || !tariff) {
            return (
                <div className="linn-container">
                    <Grid container style={{ marginTop: 40 }} spacing={24}>
                        <Paper className={classes.paper}>
                            <Loading />
                        </Paper>
                    </Grid>
                </div>
            );
        }

        return (
            <div className="linn-container">
                <Grid container style={{ marginTop: 40 }} spacing={24}>
                    <Grid item sm="12">
                        <Paper className={classes.paper}>
                            <Typography variant='h4' gutterBottom>{tariff.tariffCode}</Typography>
                            <div style={{ marginBottom: '10px' }}>
                                <Typography style={{ fontWeight: 600, display: 'inline-block' }}>Description:</Typography> 
                                <Typography style={{ display: 'inline-block' }}>{tariff.description}</Typography>
                            </div>
                            <div style={{ marginBottom: '10px' }}>
                                <Typography style={{ fontWeight: 600, display: 'inline-block' }}>US Tariff Code:</Typography> 
                                <Typography style={{ display: 'inline-block' }}>{tariff.usTariffCode}</Typography>
                            </div>
                            <div style={{ marginBottom: '10px' }}>
                                <Typography style={{ fontWeight: 600, display: 'inline-block' }}>Date Invalid:</Typography> 
                                <Typography style={{ display: 'inline-block' }}>{tariff.dateInvalid}</Typography>
                            </div>
                            <div style={{ marginBottom: '10px' }}>
                                <Typography style={{ fontWeight: 600, display: 'inline-block' }}>Duty %:</Typography> 
                                <Typography style={{ display: 'inline-block' }}>{tariff.duty}</Typography>
                            </div>
                            <span> </span>
                            <div className={classes.pullRight}>
                                <Button id="back-button"
                                    component={Link}
                                    to="/products/maint/tariffs">
                                    Back
                                </Button>

                                <Button id="edit-button"
                                    variant="outlined"
                                    component={Link}
                                    variant="contained"
                                    color="primary"
                                    to={`${getSelfHref(tariff)}/edit`}>
                                    Edit
                                </Button>
                            </div>
                        </Paper>
                    </Grid>
                </Grid>
            </div>
        );
    }
}

export default withStyles(styles)(Tariff);