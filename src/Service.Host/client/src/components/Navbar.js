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
import config from '../config';

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
    },
    container: {
        width: '100%'
    }
});

function Navbar({ classes, menu, loading, username }) {
    const [selected, setSelected] = useState(false);
    const [anchorEl, setAnchorEl] = useState();
    if (menu) {
        const menuIds = menu.map(item => item.id);

        const handleClick = event => {
            setAnchorEl(event.currentTarget);
        };
        const handleClose = () => {
            setAnchorEl();
        };
        const handleSignOut = () => {
            window.location.assign(`${config.authorityUri}account/logout`);
        };

        return (
            <ClickAwayListener onClickAway={() => setSelected(false)}>
                <div className={classes.root}>
                    {menu && !loading && (
                        <AppBar position="static" color="default">
                            <Toolbar classes={{ gutters: classes.toolbar }}>
                                <Grid
                                    container
                                    alignItems="center"
                                    justify="space-between"
                                    spacing={24}
                                    classes={{ container: classes.container }}
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
                                                {menu.map(item => (
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
                                        <Grid item xs={1}>
                                            <Typography variant="h4">
                                                <AccountCircle
                                                    aria-owns={anchorEl ? 'simple-menu' : undefined}
                                                    onClick={handleClick}
                                                    id={menu.length}
                                                    key={menu.length}
                                                />
                                            </Typography>
                                        </Grid>
                                        <Menu
                                            id="simple-menu"
                                            anchorEl={anchorEl}
                                            open={Boolean(anchorEl)}
                                            onClose={handleClose}
                                        >
                                            <MenuItem onClick={handleClose}>{username}</MenuItem>
                                            {username && (
                                                <span>
                                                    <MenuItem onClick={handleSignOut}>
                                                        Sign Out
                                                    </MenuItem>
                                                </span>
                                            )}
                                        </Menu>
                                    </Fragment>
                                </Grid>
                            </Toolbar>
                        </AppBar>
                    )}
                    {menuIds.map(
                        (item, i) =>
                            selected === i && (
                                <Panel
                                    key={item}
                                    section={menu.filter(e => e.id === item)[0]}
                                    id={item}
                                    style={{ align: 'right' }}
                                    anchorEl={item.id}
                                    close={() => setSelected(false)}
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
                <Toolbar classes={{ gutters: classes.toolbar }} />
            </AppBar>
        </div>
    );
}

Navbar.propTypes = {
    classes: PropTypes.shape({}).isRequired,
    menu: PropTypes.arrayOf(PropTypes.shape({})),
    history: PropTypes.shape({}).isRequired,
    loading: PropTypes.bool,
    username: PropTypes.string
};

Navbar.defaultProps = {
    menu: null,
    loading: false,
    username: ''
};

export default withStyles(styles)(Navbar);
