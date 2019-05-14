import React from 'react';
import { Link } from 'react-router-dom';
import { withStyles } from '@material-ui/core/styles';
import { List, ListItem, Paper, Typography } from '@material-ui/core';
import PropTypes from 'prop-types';

const styles = () => ({
    root: {
        margin: '40px',
        padding: '40px'
    }
});

const App = ({ classes }) => (
    <Paper className={classes.root}>
        <Typography variant="h6">Products</Typography>
        <List>
            <ListItem component={Link} to="/products/maint/sernos-configs" button>
                <Typography color="primary">Sernos Config Types</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/maint/serial-number-transactions" button>
                <Typography color="primary">Sernos Transaction Types</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/maint/sales-articles" button>
                <Typography color="primary">Sales Article Details</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/maint/product-ranges" button>
                <Typography color="primary">Product Ranges</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/maint/sales-packages" button>
                <Typography color="primary">Sales Packages</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/maint/root-products" button>
                <Typography color="primary">Root Products</Typography>
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
            <ListItem
                component={Link}
                to="/products/reports/sales-article-core-types/report"
                button
            >
                <Typography color="primary">Sales Article Core Types Report</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/reports/products-on-hold" button>
                <Typography color="primary">Products On Hold</Typography>
            </ListItem>
        </List>
        <Typography variant="h6">Utilities</Typography>
        <List>
            <ListItem component={Link} to="/products/maint/serial-numbers" button>
                <Typography color="primary">Serial Numbers</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/maint/sa-core-types" button>
                <Typography color="primary">Sales Article Core Types</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/maint/sernos-sequences" button>
                <Typography color="primary">Sernos Sequences</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/maint/tariffs" button>
                <Typography color="primary">Tariffs</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/maint/types-of-sale" button>
                <Typography color="primary">Types of Sale</Typography>
            </ListItem>
            <ListItem component={Link} to="/products/maint/vat-codes" button>
                <Typography color="primary">Vat Codes</Typography>
            </ListItem>
        </List>
    </Paper>
);

App.propTypes = {
    classes: PropTypes.shape({})
};

App.defaultProps = {
    classes: {}
};

export default withStyles(styles)(App);
