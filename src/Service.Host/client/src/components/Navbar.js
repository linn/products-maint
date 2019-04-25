import React, { useState, Fragment } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import { Tabs, Tab, AppBar, ClickAwayListener, Menu, MenuItem } from '@material-ui/core';
import AccountCircle from '@material-ui/icons/AccountCircle';

import Panel from './Panel';

const styles = {
    root: {
        width: '100%',
        position: 'absolute',
        top: 0,
        zIndex: 10
    },
    tab: {
        minWidth: 20
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
        float: 'right'
    }
};

function Navbar({ classes, menu, loading }) {
    const { sections } = menu;
    const menuIds = sections.map(item => item.id);
    const [selected, setSelected] = useState(false);
    const [anchorEl, setAnchorEl] = useState();
    const handleClick = event => {
        setAnchorEl(event.currentTarget);
    };
    const handleClose = () => {
        setAnchorEl();
    };
    // history.push(`/${menuIds[value]}`); get history comes in as props

    return (
        <ClickAwayListener onClickAway={() => setSelected(false)}>
            <div className={classes.root}>
                <AppBar position="static" color="default">
                    {menu && !loading ? (
                        <Fragment>
                            <Tabs
                                value={selected}
                                onChange={(event, value) => setSelected(value)}
                                scrollButtons="auto"
                                variant="fullWidth"
                                indicatorColor="primary"
                                textColor="primary"
                            >
                                {sections.map(item => (
                                    <Tab
                                        id={item.id}
                                        key={item.id}
                                        classes={{ root: classes.tab }}
                                        label={
                                            <span className={classes.tabLabel}>{item.title}</span>
                                        }
                                        selected={false}
                                    />
                                ))}
                                <Tab
                                    aria-owns={anchorEl ? 'simple-menu' : undefined}
                                    onClick={handleClick}
                                    id={sections.length}
                                    key={sections.length}
                                    classes={{ root: classes.tab }}
                                    label={<AccountCircle />}
                                    selected={false}
                                />{' '}
                            </Tabs>
                            <Menu
                                id="simple-menu"
                                anchorEl={anchorEl}
                                open={Boolean(anchorEl)}
                                onClose={handleClose}
                            >
                                <MenuItem onClick={handleClose}>{menu.myStuff.userName}</MenuItem>
                                <Fragment>
                                    {menu.myStuff.groups.map(group => (
                                        <a href={group.items[0].href}>
                                            <MenuItem onClick={handleClose}>
                                                {group.items[0].title}
                                            </MenuItem>{' '}
                                        </a>
                                    ))}
                                </Fragment>
                            </Menu>
                        </Fragment>
                    ) : (
                        <Fragment />
                    )}
                </AppBar>
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
