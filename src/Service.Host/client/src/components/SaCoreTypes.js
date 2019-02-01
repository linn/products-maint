import React from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
import { withStyles } from '@material-ui/core/styles';
import { List, ListItem, Paper, Typography, Button } from '@material-ui/core';
import { Title, Loading } from '@linn-it/linn-form-components-library';

const styles = () => ({
    root: {
        margin: '40px',
        padding: '40px',
        marginBottom: '80px'
    },
    createButton: {
        float: 'right'
    }
});

const SaCoreTypes = ({ classes, saCoreTypes, loading }) => (
    <div>
        {loading ? (
            <Loading />
        ) : (
            <Paper className={classes.root}>
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
            </Paper>
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
