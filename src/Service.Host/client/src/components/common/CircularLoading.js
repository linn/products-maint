import React from 'react';
import { CircularProgress } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';

const styles = () => ({
    root: {
        display: 'flex',
        justifyContent: 'center',
        width: '100%',
        margin: 'auto'
    },
    loading: {
        margin: 10
    }
})

const CircularLoading = ({ classes }) => (
    <div className={classes.root}>
        <CircularProgress className={classes.loading} />
    </div>
);

export default withStyles(styles)(CircularLoading);