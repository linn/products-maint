import React from 'react';
import Grid from '@material-ui/core/Grid';
import { withStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import { Typeahead } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';

const styles = theme => ({
    paper: {
        padding: theme.spacing.unit * 6
    }
});

const SalesArticles = ({ items, classes, fetchItems, loading, clearSearch }) => {
    const forecastItems = items.map(item => ({
        ...item,
        name: item.articleNumber
    }));

    return (
        <Grid container spacing={24}>
            <Grid item xs={12}>
                <Paper className={classes.paper}>
                    <Typeahead
                        items={forecastItems}
                        fetchItems={fetchItems}
                        clearSearch={clearSearch}
                        loading={loading}
                        title="Search for Sales Article"
                    />
                </Paper>
            </Grid>
        </Grid>
    );
};

SalesArticles.propTypes = {
    items: PropTypes.arrayOf(
        PropTypes.shape({
            id: PropTypes.oneOfType([PropTypes.string, PropTypes.number]),
            name: PropTypes.string,
            description: PropTypes.string,
            href: PropTypes.string
        })
    ).isRequired,
    classes: PropTypes.shape({}).isRequired,
    loading: PropTypes.bool,
    fetchItems: PropTypes.func.isRequired,
    clearSearch: PropTypes.func.isRequired
};

SalesArticles.defaultProps = {
    loading: false
};

export default withStyles(styles)(SalesArticles);