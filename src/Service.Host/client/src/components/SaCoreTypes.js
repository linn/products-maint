import React from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
import { withStyles } from '@material-ui/core/styles';
import { List, ListItem, Typography, Button } from '@material-ui/core';
import { Title, Loading, Page } from '@linn-it/linn-form-components-library';

const styles = () => ({
    createButton: {
        float: 'right'
    }
});

const SaCoreTypes = ({ classes, saCoreTypes, loading, history }) => (
    <div>
        {loading ? (
            <Loading />
        ) : (
            <Page history={history}>
                <Title text="Sales Article Core Types" />
                <List>
                    {saCoreTypes.map(saCoreType => (
                        <ListItem
                            key={saCoreType.coreType}
                            component={Link}
                            to={saCoreType.href}
                            button
                        >
                            <Typography color="primary">
                                {saCoreType.coreType} - {saCoreType.description}
                            </Typography>
                        </ListItem>
                    ))}
                </List>
                <span className={classes.createButton}>
                    <Link to="/products/maint/sa-core-types/create">
                        <Button color="primary" variant="contained">
                            Create
                        </Button>
                    </Link>
                </span>
            </Page>
        )}
    </div>
);

SaCoreTypes.defaultProps = {
    saCoreTypes: {}
};

SaCoreTypes.propTypes = {
    classes: PropTypes.shape({}).isRequired,
    loading: PropTypes.bool.isRequired,
    saCoreTypes: PropTypes.shape({})
};

export default withStyles(styles)(SaCoreTypes);
