import React, { Component } from 'react';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
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
                    <Grid container spacing={24}>
                        <Paper className={classes.paper}>
                            <Loading />
                        </Paper>
                    </Grid>
                </div>
            );
        }

        return (
            <div className="linn-container">
                <Grid container spacing={24}>
                    <Grid item sm="12">
                        <Paper className={classes.paper}>
                            <h2>{tariff.tariffCode}</h2>
                            <div style={{ marginBottom: '10px' }}>
                                <strong>Description:</strong> {tariff.description}
                            </div>
                            <div style={{ marginBottom: '10px' }}>
                                <strong>US Tariff Code:</strong> {tariff.usTariffCode}
                            </div>
                            <div style={{ marginBottom: '10px' }}>
                                <strong>Date Invalid:</strong> {tariff.dateInvalid}
                            </div>
                            <div style={{ marginBottom: '10px' }}>
                                <strong>Duty %:</strong> {tariff.duty}
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