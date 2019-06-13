import React, { useState } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';import {
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

const styles = theme => {
    console.log(theme);

    return {
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
            ...theme.mixins.toolbar,
            paddingLeft: 40
        },
        container: {
            width: '100%'
        }
    };
};

// ({
//     root: {
//         position: 'absolute',
//         width: '100%',
//         top: 0,
//         zIndex: 10
//     },
//     tabLabel: {
//         fontSize: '12px'
//     },
//     panel: {
//         position: 'relative'
//     },
//     menuButton: {
//         marginLeft: -12,
//         marginRight: 20
//     },
//     fullHeight: {
//         ...theme.mixins.toolbar,
//         minWidth: '100px'
//     },
//     toolbar: {
//         paddingLeft: 0,
//         paddingRight: 0
//     },
//     tabs: {
//         ...theme.mixins.toolbar,
//         paddingLeft: 40
//     },
//     container: {
//         width: '100%'
//     }
// });

function Navigation({ classes, sections, loading, username, myStuff }) {
    const [selected, setSelected] = useState(false);
    const [anchorEl, setAnchorEl] = useState();
    if (sections) {
        const menuIds = sections.map(item => item.id);

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
                    {sections && !loading && (
                        <AppBar position="static" color="default">
                            <Toolbar classes={{ gutters: classes.toolbar }}>
                                <Grid
                                    container
                                    alignItems="center"
                                    justify="space-between"
                                    spacing={3}
                                    classes={{ container: classes.container }}
                                >
                                    <Grid item xs={11}>
                                        <Tabs
                                            classes={{
                                                root: classes.tabs
                                            }}
                                            value={selected}
                                            onChange={(event, value) => {
                                                if (selected === value) {
                                                    setSelected(false);
                                                } else {
                                                    setSelected(value);
                                                }
                                            }}
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
                                    <Grid item xs={1}>
                                        <Typography variant="h4">
                                            <AccountCircle
                                                aria-owns={anchorEl ? 'simple-menu' : undefined}
                                                onClick={handleClick}
                                                id={sections.length}
                                                key={sections.length}
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
                                        {username &&
                                            myStuff.groups.map(item => (
                                                <span>
                                                    <MenuItem onClick={handleClose}>
                                                        {item.items[0].title}
                                                    </MenuItem>
                                                </span>
                                            ))}
                                        <MenuItem onClick={handleSignOut}>Sign Out</MenuItem>
                                    </Menu>
                                </Grid>
                            </Toolbar>
                        </AppBar>
                    )}
                    {menuIds.map(
                        (item, i) =>
                            selected === i && (
                                <Panel
                                    key={item}
                                    section={sections.filter(e => e.id === item)[0]}
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

Navigation.propTypes = {
    classes: PropTypes.shape({}).isRequired,
    sections: PropTypes.arrayOf(PropTypes.shape({})),
    history: PropTypes.shape({}).isRequired,
    loading: PropTypes.bool,
    username: PropTypes.string,
    myStuff: PropTypes.shape({})
};

Navigation.defaultProps = {
    sections: null,
    myStuff: null,
    loading: false,
    username: ''
};

export default withStyles(styles)(Navigation);
