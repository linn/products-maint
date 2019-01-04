import React, { Component } from 'react';
import Grid from '@material-ui/core/Grid';
import { withStyles } from '@material-ui/core/styles';
import Typeahead from './Typeahead';
import Paper from '@material-ui/core/Paper';

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
    halfWidth: {
        width: '50%'
    },
    biggerText: {
        fontSize: 14
    }
});

class SaForecasts extends Component {
    render() {
        const { items, title, classes, fetchItems, loading } = this.props;

        return (
            <div className="linn-container">
                <Grid container spacing={24}>
                    <Grid item xs={12}>
                        <Paper className={classes.paper}>
                            <Typeahead items={items} fetchItems={fetchItems} loading={loading} classes={classes} title={title} />
                        </Paper>
                    </Grid>
                </Grid>
            </div>
        );
    }
}

export default withStyles(styles)(SaForecasts);