import React, { useState, Fragment } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import {
    Tabs,
    Tab,
    AppBar,
    ClickAwayListener,
    Menu,
    MenuItem,
    Toolbar,
    Grid,
    Typography
} from '@material-ui/core';
import AccountCircle from '@material-ui/icons/AccountCircle';

import Panel from './Panel';

const styles = theme => ({
    root: {
        position: 'absolute',
        width: '100%',
        top: 0,
        zIndex: 10
    },
    tabLabel: {
        fontSize: '12px'
    },
    panel: {
        position: 'relative'
    },
    menuButton: {
        marginLeft: -12,
        marginRight: 20
    },
    userTab: {
        // float: 'right'
    },
    fullHeight: {
        ...theme.mixins.toolbar,
        minWidth: '100px'
    },
    toolbar: {
        paddingLeft: 0,
        paddingRight: 0
    },
    tabs: {
        ...theme.mixins.toolbar
        // width: '80%'
    }
});

function Navbar({ classes, menu, loading }) {
    const [selected, setSelected] = useState(false);
    const [anchorEl, setAnchorEl] = useState();
    if (menu) {
        const { sections } = menu;
        const menuIds = sections.map(item => item.id);

        const handleClick = event => {
            setAnchorEl(event.currentTarget);
        };
        const handleClose = () => {
            setAnchorEl();
        };

        return (
            <ClickAwayListener onClickAway={() => setSelected(false)}>
                <div className={classes.root}>
                    {menu && !loading ? (
                        <AppBar position="static" color="default">
                            <Toolbar classes={{ gutters: classes.toolbar }}>
                                <Grid
                                    container
                                    alignItems="center"
                                    justify="space-between"
                                    spacing={24}
                                >
                                    <Fragment>
                                        <Grid item xs={11}>
                                            <Tabs
                                                classes={{
                                                    root: classes.tabs
                                                }}
                                                value={selected}
                                                onChange={(event, value) => setSelected(value)}
                                                scrollButtons="auto"
                                                variant="scrollable"
                                                indicatorColor="primary"
                                                textColor="primary"
                                            >
                                                {sections.map(item => (
                                                    <Tab
                                                        id={item.id}
                                                        key={item.id}
                                                        classes={{ root: classes.fullHeight }}
                                                        label={
                                                            <span className={classes.tabLabel}>
                                                                {item.title}
                                                            </span>
                                                        }
                                                        selected={false}
                                                    />
                                                ))}
                                            </Tabs>
                                        </Grid>
                                        <Grid item xs={1} classes={{ root: classes.fullHeight }}>
                                            <Typography variant="h4">
                                                <AccountCircle
                                                    aria-owns={anchorEl ? 'simple-menu' : undefined}
                                                    onClick={handleClick}
                                                    id={sections.length}
                                                    key={sections.length}
                                                />{' '}
                                            </Typography>
                                        </Grid>

                                        <Menu
                                            id="simple-menu"
                                            anchorEl={anchorEl}
                                            open={Boolean(anchorEl)}
                                            onClose={handleClose}
                                        >
                                            <MenuItem onClick={handleClose}>
                                                {menu.myStuff.userName}
                                            </MenuItem>
                                            {menu.myStuff.userName && (
                                                <Fragment>
                                                    {menu.myStuff.groups.map(group => (
                                                        <a href={group.items[0].href}>
                                                            <MenuItem onClick={handleClose}>
                                                                {group.items[0].title}
                                                            </MenuItem>{' '}
                                                        </a>
                                                    ))}
                                                </Fragment>
                                            )}
                                        </Menu>
                                    </Fragment>
                                </Grid>
                            </Toolbar>
                        </AppBar>
                    ) : (
                        <Fragment />
                    )}
                    {menuIds.map(
                        (item, i) =>
                            selected === i && (
                                <Panel
                                    section={sections.filter(e => e.id === item)[0]}
                                    id={item}
                                    style={{ align: 'right' }}
                                    anchorEl={item.id}
                                />
                            )
                    )}
                </div>
            </ClickAwayListener>
        );
    }
    return (
        <div className={classes.root}>
            <AppBar position="static" color="default">
                <Toolbar classes={{ gutters: classes.toolbar }} />{' '}
            </AppBar>{' '}
        </div>
    );
}

Navbar.propTypes = {
    classes: PropTypes.shape({}).isRequired,
    menu: PropTypes.arrayOf(PropTypes.shape({})),
    history: PropTypes.shape({}).isRequired,
    loading: PropTypes.bool
};

Navbar.defaultProps = {
    menu: {},
    loading: false
};

export default withStyles(styles)(Navbar);
