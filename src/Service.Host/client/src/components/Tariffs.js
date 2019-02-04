import React, { Component } from 'react';
import { Paper, Grid, TextField, Typography, Button, List, ListItem, InputAdornment } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import { Link } from 'react-router-dom';
import { Loading } from '@linn-it/linn-form-components-library';
import { getSelfHref } from '../helpers/utilities';

const styles = theme => ({
    paper: {
        padding: theme.spacing.unit * 6,
        marginTop: 40
    },
    boldHeader: {
        fontWeight: 'bold',
        width: '140px'
    },
    pullRight: {
        float: 'right'
    },
    halfWidth: {
        width: '50%'
    },
    biggerText: {
        fontSize: 14
    }
});

class Tariffs extends Component {
    state = { searchTerm: '' }

    render() {
        const { tariffs, loading, classes } = this.props;

        return (
            <div className="linn-container">
                <Grid container spacing={24}>
                    <Grid item xs="12" sm="12">
                        <Paper className={classes.paper}>
                            <Typography variant='h4' gutterBottom>Tariffs</Typography>
                            <Button
                                className={classes.pullRight}
                                variant="outlined"
                                component={Link}
                                to="/products/maint/tariffs/create"
                                size="large">
                                Create
                            </Button>
                            <TextField
                                className={classes.halfWidth}
                                placeholder="Search by tariff code or description"
                                onChange={e => this.handleSearchTermChange(e)}
                                type="search"
                                margin="normal"
                                variant="outlined"
                                InputProps={{
                                    startAdornment: <InputAdornment position="start">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M15.5 14h-.79l-.28-.27C15.41 12.59 16 11.11 16 9.5 16 5.91 13.09 3 9.5 3S3 5.91 3 9.5 5.91 16 9.5 16c1.61 0 3.09-.59 4.23-1.57l.27.28v.79l5 4.99L20.49 19l-4.99-5zm-6 0C7.01 14 5 11.99 5 9.5S7.01 5 9.5 5 14 7.01 14 9.5 11.99 14 9.5 14z" /></svg>
                                    </InputAdornment>,
                                }}
                            />

                            {tariffs.length > 0
                                ? (
                                    <List>
                                        {tariffs.map((tariff, i) => (
                                            <ListItem key={i} key={i} button component="a" href={getSelfHref(tariff)}>
                                                <Typography style={{ fontWeight: 600, width: 140 }}>{tariff.tariffCode}</Typography>
                                                <Typography>{tariff.description}</Typography>
                                            </ListItem>
                                        ))}
                                    </List>
                                )
                                : loading ? <Loading />
                                    : <div><Typography>No matching tariffs</Typography></div>
                            }
                        </Paper>
                    </Grid>
                </Grid>
            </div>
        );
    }

    handleSearchTermChange(e) {
        const { fetchTariffs } = this.props;
        const searchTerm = e.target.value;

        this.setState({ searchTerm });

        fetchTariffs(searchTerm);
    }
}

export default withStyles(styles)(Tariffs);