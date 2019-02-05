import React, { Fragment } from 'react';
import { Link } from 'react-router-dom';
import CircularLoading from './common/CircularLoading';
import ErrorCard from '../components/common/ErrorCard';
import { withStyles } from '@material-ui/core/styles';
import { List, ListItem, Typography } from '@material-ui/core';
import { Page } from '@linn-it/linn-form-components-library';

const styles = theme => ({
    root: {
        ...theme.typography,
        margin: '40px',
        padding: '40px'
    }
});

const SernosConfigs = ({ sernosConfigs, loading, errorMessage, classes, history }) => (
    <Page history={history}>
        {loading || !sernosConfigs ? (
            errorMessage ? (
                <ErrorCard errorMessage={errorMessage} />
            ) : (
                <CircularLoading />
            )
        ) : (
            <Fragment>
                <Typography variant="h3" gutterBottom>
                    Sernos Config
                </Typography>
                <List>
                    {sernosConfigs.map(sc => (
                        <ListItem key={sc.href} component={Link} to={sc.href} button>
                            {sc.name} - {sc.description}
                        </ListItem>
                    ))}
                    <ListItem component={Link} to="/products/maint/sernos-configs/create" button>
                        <Typography color="primary">
                            Create new serial number config type
                        </Typography>
                    </ListItem>
                </List>
            </Fragment>
        )}
    </Page>
);

export default withStyles(styles)(SernosConfigs);
