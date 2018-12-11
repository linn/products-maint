import React, { Component } from 'react';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import InputAdornment from '@material-ui/core/InputAdornment';
import { withStyles } from '@material-ui/core/styles';
import { Link } from 'react-router-dom';
import { Loading } from './common/Loading';
import { getSelfHref } from '../helpers/utilities';


const styles = theme => ({
    paper: {
        padding: theme.spacing.unit * 6
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
        fontSize:14
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
                            <h2>Tariffs</h2>
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
                                    classes: {
                                        input: classes.biggerText
                                    },
                                    startAdornment: <InputAdornment position="start">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M15.5 14h-.79l-.28-.27C15.41 12.59 16 11.11 16 9.5 16 5.91 13.09 3 9.5 3S3 5.91 3 9.5 5.91 16 9.5 16c1.61 0 3.09-.59 4.23-1.57l.27.28v.79l5 4.99L20.49 19l-4.99-5zm-6 0C7.01 14 5 11.99 5 9.5S7.01 5 9.5 5 14 7.01 14 9.5 11.99 14 9.5 14z" /></svg>
                                    </InputAdornment>,
                                }}
                            />

                            {tariffs.length > 0
                                ? (
                                    <List>
                                        {tariffs.map((tariff, i) => (
                                            <ListItem key={i} key={i} button component="a" href={getSelfHref(tariff)}><span className={classes.boldHeader}>{tariff.tariffCode}</span>{tariff.description}</ListItem>
                                        ))}
                                    </List>
                                )
                                : loading ? <Loading />
                                : <div>No matching tariffs</div>
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