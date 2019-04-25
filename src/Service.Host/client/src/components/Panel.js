import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import { Paper, Grid, List, ListItem, Typography } from '@material-ui/core';

const styles = {
    listItemText: {
        '&:first-child': {
            paddingLeft: 30,
            paddingTop: 0,
            paddingBottom: 0
        }
    },
    paper: {
        backgroundColor: '#f5f5f5',
        zIndex: -1
    },
    menuItems: {
        fontSize: '12px',
        lineHeight: 2
    }
};

function Panel({ section, classes }) {
    const { columns } = section;

    return (
        <Paper classes={{ root: classes.paper }}>
            <Grid container justify="left">
                {columns.map(col => (
                    <Grid item xs={12} sm={6} md={4} lg={3} xl={3}>
                        {col.categories.map(category => (
                            <List>
                                <ListItem>
                                    <Typography variant="button" gutterBottom>
                                        {category.title.replace('&amp;', '&')}
                                    </Typography>
                                </ListItem>
                                {category.items.map(entry => (
                                    <Fragment>
                                        {entry.showInMenu && (
                                            <a
                                                href={entry.href}
                                                style={{ textDecoration: 'none !important' }}
                                            >
                                                <ListItem
                                                    classes={{ root: classes.listItemText }}
                                                    button
                                                >
                                                    <Typography
                                                        variant="overline"
                                                        classes={{ overline: classes.menuItems }}
                                                    >
                                                        {entry.title}
                                                    </Typography>
                                                </ListItem>
                                            </a>
                                        )}{' '}
                                    </Fragment>
                                ))}
                            </List>
                        ))}
                    </Grid>
                ))}
            </Grid>
        </Paper>
    );
}

Panel.propTypes = {
    classes: PropTypes.shape({}).isRequired,
    section: PropTypes.shape({}).isRequired
};

export default withStyles(styles)(Panel);
