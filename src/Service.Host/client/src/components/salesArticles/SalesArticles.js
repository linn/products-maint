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

class SalesArticles extends Component {
    render() {
        const { items, classes, fetchItems, loading, clearSearch } = this.props;
        const forecastItems = items.map(item => ({ ...item, href: `${item.href.substring(0, item.href.indexOf('?'))}/details?${item.href.substring(item.href.indexOf('?') + 1, item.href.length)}` }));

        return (
            <div className="linn-container">
                <Grid container spacing={24}>
                    <Grid item xs={12}>
                        <Paper className={classes.paper}>
                            <Typeahead items={forecastItems} fetchItems={fetchItems} clearSearch={clearSearch} loading={loading} title="Search for Sales Article" />
                        </Paper>
                    </Grid>
                </Grid>
            </div>
        );
    }
}

export default withStyles(styles)(SalesArticles);