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

class SernosConfigs extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        const { sernosConfigs, loading, errorMessage, classes } = this.props;

        if (loading || !sernosConfigs) {
            return (
                errorMessage ?
                    <Grid>
                        <Paper style={{ marginTop: "15px" }}  >
                            <strong>{errorMessage}</strong>
                        </Paper >
                    </Grid>
                    : <Loading />);
        }

        return (
            <div className="linn-container" >
                <div className={classes.root}>
                    <h2>Serial Number Config Types</h2>
                    <List>
                        {sernosConfigs.map((sc, i) => (
                            <ListItem key={i} component={Link} to={sc.href} button>{sc.name} - {sc.description}</ListItem>
                        ))}
                    </List>
                </div>
                <Link style={{ display: 'block' }} to="/products/maint/sernos-configs/create">Create new serial number config type</Link>
            </div>
        );
    }
}

export default withStyles(styles)(SernosConfigs);

