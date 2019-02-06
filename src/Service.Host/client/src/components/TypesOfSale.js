import React, { Fragment } from 'react';
import { Link } from 'react-router-dom';
import { withStyles } from '@material-ui/core/styles';
import { List, ListItem, Paper, Typography } from '@material-ui/core';
import { ErrorCard } from '@linn-it/linn-form-components-library';
import CircularLoading from './common/CircularLoading';

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
                            <ListItem key={ts.href} component={Link} to={ts.href} button>
                                <Typography>{ts.name} - {ts.description}</Typography>
                            </ListItem>
                        ))}
                        <ListItem component={Link} to="/products/maint/types-of-sale/create" button>
                            <Typography color="primary">Create new Type of Sale</Typography>
                        </ListItem>
                    </List>                    
                </Fragment>
            )
        }
    </Paper>
);

export default withStyles(styles)(TypesOfSale);