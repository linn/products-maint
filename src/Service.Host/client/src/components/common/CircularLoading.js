import React from 'react';
import { CircularProgress } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import PropTypes from 'prop-types';

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
});

const CircularLoading = ({ classes }) => (
    <div className={classes.root}>
        <CircularProgress className={classes.loading} />
    </div>
);

CircularLoading.propTypes = {
    classes: PropTypes.shape({})
};

CircularLoading.defaultProps = {
    classes: {}
};

export default withStyles(styles)(CircularLoading);
