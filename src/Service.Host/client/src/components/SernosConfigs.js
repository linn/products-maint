import React, { Component, Fragment } from 'react';
import { Link } from 'react-router-dom';
import CircularLoading from './common/CircularLoading';
import ErrorCard from '../components/common/ErrorCard';
import { withStyles } from '@material-ui/core/styles';
import { List, ListItem, Paper, Typography } from '@material-ui/core';

const styles = () => ({
    root: {
        margin: 40,
        padding: 40
    }
});

const SernosConfigs = ({ sernosConfigs, loading, errorMessage, classes }) => (
    <Paper className={classes.root}>
        {loading || !sernosConfigs
            ? errorMessage
                ? <ErrorCard errorMessage={errorMessage} />
                : <CircularLoading />
            : (
                <Fragment>
                    <Typography variant='h2' align='center' gutterBottom>
                        Sernos Config
                    </Typography>
                    <List>
                        {sernosConfigs.map((sc, i) => (
                            <ListItem key={i} component={Link} to={sc.href} button>{sc.name} - {sc.description}</ListItem>
                        ))}
                    </List>
                    <Link style={{ display: 'block' }} to="/products/maint/sernos-configs/create">Create new serial number config type</Link>
                </Fragment>
            )
        }
    </Paper>
)

export default withStyles(styles)(SernosConfigs);

