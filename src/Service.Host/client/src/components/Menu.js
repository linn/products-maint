import React from 'react';
import PropTypes from 'prop-types';
import Divider from '@material-ui/core/Divider';
import { List, ListItem, Typography } from '@material-ui/core';
import ListSubheader from '@material-ui/core/ListSubheader';
import MuiThemeProvider from '@material-ui/core/styles/MuiThemeProvider';
import { createMuiTheme, withStyles } from '@material-ui/core/styles';
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

const MenuPage = ({ classes, section }) => (
    <Page>
        <MuiThemeProvider theme={theme}>
            <List className={classes.root} subheading={<li />}>
                {section !== null
                    ? section.map(item => (
                          <li key={item.title} className={classes.listSection}>
                              <ul className={classes.ul}>
                                  <ListSubheader>
                                      {item.title} <Divider />
                                  </ListSubheader>
                                  <div className={classes.innerList}>
                                      {item.items.map(entry => (
                                          <a href={entry.href} key={entry.title}>
                                              <ListItem>
                                                  <Typography color="primary">
                                                      {entry.title}
                                                  </Typography>
                                              </ListItem>
                                          </a>
                                      ))}
                                  </div>
                              </ul>
                          </li>
                      ))
                    : ''}
            </List>
        </MuiThemeProvider>
    </Page>
);

MenuPage.propTypes = {
    match: PropTypes.shape({}).isRequired,
    classes: PropTypes.shape({}).isRequired,
    section: PropTypes.arrayOf(PropTypes.shape({}))
};

MenuPage.defaultProps = {
    section: []
};

export default withStyles(styles)(MenuPage);
