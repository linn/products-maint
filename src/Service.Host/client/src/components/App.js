import React from 'react';
import { Link } from 'react-router-dom';
import { withStyles } from '@material-ui/core/styles';
import { List, ListItem, Paper, Typography } from '@material-ui/core';

const styles = () => ({
    root: {
        margin: '40px',
        padding: '40px'
    },
});

const App = ({ classes }) => (
    <Paper className={classes.root}>
        <Typography variant="h6">Products</Typography>
        <List>
            <ListItem component={Link} to="/products/maint/sernos-configs" button>
                <Typography color="primary">Sernos Config Types</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/maint/sales-articles" button>
                <Typography color="primary">Sales Article Forecast Details</Typography>
            </ListItem>
        </List>
        <Typography variant="h6">Reports</Typography>
        <List>
            <ListItem component={Link} to="/products/reports/sales-article-ean-codes" button>
                <Typography color="primary">Sales Article Ean Codes Report</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/reports/carton-details/report" button>
                <Typography color="primary">Carton Details Report</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/reports/product-ranges" button>
                <Typography color="primary">Product Ranges Report</Typography>
            </ListItem>
        </List>
        <Typography variant="h6">Utlities</Typography>
        <List>
            <ListItem component={Link} to="/products/maint/tariffs" button>
                <Typography color="primary">Tariffs</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/maint/sa-core-types" button>
                <Typography color="primary">Sales Article Core Types</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/maint/types-of-sale" button>
                <Typography color="primary">Types of Sale</Typography>
            </ListItem>
        </List>
    </Paper>
);

export default withStyles(styles)(App);