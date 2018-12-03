import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import { Loading } from './common/Loading';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import { withStyles } from '@material-ui/core/styles';

const styles = theme => ({
    root: {
        width: '100%'
    }
});

class SaCoreTypes extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        const { saCoreTypes, loading, errorMessage, classes } = this.props;

        if (loading || !saCoreTypes) {
            return( 
                errorMessage?
                <Grid>
                    <Paper style={{ marginTop: "15px" }}  >
                    <strong>{errorMessage}</strong>
                    </Paper >
                </Grid>
        :  <Loading />);
        }

        return (
            <div className="linn-container" >
                <div className={classes.root}>
                <h2>Sales Article Core Types</h2>
                    <List>
                        {saCoreTypes.map((ct, i) => (<ListItem key={i} button component="a" href={ct.href}>
                                {ct.coreType} - {ct.description}
                            </ListItem>))}
                    </List>
                </div>
                <Link style={{ display: 'block' }} to="/products/maint/sa-core-types/create">Create new sales article core type</Link>
            </div>
        );
    }
}

export default withStyles(styles)(SaCoreTypes);

