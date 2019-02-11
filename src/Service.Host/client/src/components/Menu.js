import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Divider from '@material-ui/core/Divider';
import { List, ListItem, Typography } from '@material-ui/core';
import ListSubheader from '@material-ui/core/ListSubheader';
import MuiThemeProvider from '@material-ui/core/styles/MuiThemeProvider';
import { createMuiTheme, withStyles } from '@material-ui/core/styles';
import { Link } from 'react-router-dom';
import Page from '../containers/Page';

const styles = theme => ({
    fragment: {
        overflow: 'hidden'
    },
    root: {
        width: '100%',
        backgroundColor: theme.palette.background.paper,
        position: 'relative',
        overflow: 'auto'
    },
    listSection: {
        backgroundColor: 'inherit',
        margin: '10px'
    },
    ul: {
        backgroundColor: 'inherit',
        padding: 0
    },
    innerList: {
        margin: '20px'
    },
    subHeaders: {
        fontSize: '18px',
        fontWeight: 1000,
        color: 'black'
    }
});

const theme = createMuiTheme({
    overrides: {
        MuiListSubheader: {
            root: {
                fontSize: '32px',
                color: 'black',
                padding: '15px'
            }
        },
        MuiListItem: {
            root: {
                paddingTop: '0px',
                paddingBottom: '0px'
            }
        }
    }
});

const menu = require('./menu.json').sections; // should get this via GET request to /intranet/menu

const PinnedSubheaderList = ({ classes, list }) => (
    <List className={classes.root} subheading={<li />}>
        {list.map(item => (
            <li key={item.title} className={classes.listSection}>
                <ul className={classes.ul}>
                    <ListSubheader>
                        {item.title} <Divider />
                    </ListSubheader>
                    <div className={classes.innerList}>
                        {item.items.map(entry => (
                            <a href={entry.href} key={entry.title}>
                                <ListItem>
                                    <Typography color="primary"> {entry.title} </Typography>
                                </ListItem>{' '}
                            </a>
                        ))}
                    </div>
                </ul>
            </li>
        ))}
    </List>
);

class MenuPage extends Component {
    getMenu() {
        const { match } = this.props;
        const id = match.params.sectionId;
        const section = menu.filter(x => x.id === id);
        const { columns } = section[0];
        const categoriesListArray = [];

        columns.forEach(column => {
            categoriesListArray.push(column.categories);
        });

        const lists = [];

        categoriesListArray.forEach(categoriesList => {
            lists.push(categoriesList);
        });

        const subHeaders = [];
        lists.forEach(list => {
            list.forEach(item => {
                subHeaders.push(item);
            });
        });
        return subHeaders;
    }

    render() {
        const { classes } = this.props;
        return (
            <Page>
                <MuiThemeProvider theme={theme}>
                    <PinnedSubheaderList list={this.getMenu()} classes={classes} />
                </MuiThemeProvider>
            </Page>
        );
    }
}

MenuPage.propTypes = {
    match: PropTypes.shape({}).isRequired,
    classes: PropTypes.shape({}).isRequired
};

export default withStyles(styles)(MenuPage);
