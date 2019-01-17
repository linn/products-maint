import React, { Fragment } from 'react';
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

const TypesOfSale = ({ typesOfSale, loading, errorMessage, classes }) => (
    <Paper className={classes.root}>
        {loading || !typesOfSale
            ? errorMessage
                ? <ErrorCard errorMessage={errorMessage} />
                : <CircularLoading />
            : (
                <Fragment>
                    <Typography variant="h2" align="center" gutterBottom>
                        Types of Sale
                    </Typography>
                    <List>
                        {typesOfSale.map((ts) => (
                            <ListItem key={ts.href} component={Link} to={ts.href} button>{ts.name} - {ts.description}</ListItem>
                        ))}
                    </List>
                    <Link style={{ display: 'block' }} to="/products/maint/types-of-sale/create">Create new Type of Sale</Link>
                </Fragment>
            )
        }
    </Paper>
);

export default withStyles(styles)(TypesOfSale);