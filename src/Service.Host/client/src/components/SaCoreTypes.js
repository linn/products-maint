import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Grid, Paper, List, ListItem, Typography } from '@material-ui/core';
import { Loading } from './common/Loading';
import { withStyles } from '@material-ui/core/styles';

const styles = () => ({
    root: {
        width: '100%',
        marginTop: 40
    }
});

class SaCoreTypes extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        const { saCoreTypes, loading, errorMessage, classes } = this.props;

        if (loading || !saCoreTypes) {
            return (
                errorMessage
                    ? (
                        <Grid>
                            <Paper style={{ marginTop: "15px" }}  >
                                <strong>{errorMessage}</strong>
                            </Paper >
                        </Grid>
                    ) : <Loading />
            );
        }

        return (
            <div className="linn-container" >
                <div className={classes.root}>
                    <Typography variant="h4" gutterBottom>Sales Article Core Types</Typography>
                    <List>
                        {saCoreTypes.map((ct, i) => (
                            <ListItem key={i} button>
                                <Link style={{ display: 'block' }} to={ct.href}>
                                    <Typography color='primary'>{ct.coreType} - {ct.description}</Typography>
                                </Link>
                            </ListItem>
                        ))}
                        <ListItem button>
                            <Link style={{ display: 'block' }} to="/products/maint/sa-core-types/create">
                                <Typography color="primary">Create new sales article core type</Typography>
                            </Link>
                        </ListItem>
                    </List>
                </div>
            </div>
        );
    }
}

export default withStyles(styles)(SaCoreTypes);

