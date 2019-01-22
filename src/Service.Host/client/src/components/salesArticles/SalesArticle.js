import React, { Component } from 'react';
import Grid from '@material-ui/core/Grid';
import { withStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import { Title, Loading } from '@linn-it/linn-form-components-library';

const styles = theme => ({
    paper: {
        padding: theme.spacing.unit * 6
    }
});

class SalesArticle extends Component {
    render() {
        const { item, classes } = this.props;

        return (
                <Grid container spacing={24}>
                    <Grid item xs={12}>
                        <Paper className={classes.paper}>
                            <Title text={item.id} />
                        </Paper>
                    </Grid>
                </Grid>
        );
    }
}

export default withStyles(styles)(SalesArticle);