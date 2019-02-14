import React, { useState, Fragment } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';

const styles = {
    root: {
        width: '100%',
        position: 'absolute',
        top: 0
    },

    tab: {
        minWidth: 20
    },

    tabLabel: {
        fontSize: '12px'
    }
};

function Navbar({ classes, menu, loading, history }) {
    const [selected, setSelected] = useState(false);

    const handleChange = (event, value) => {
        const menuIds = menu.map(item => item.id);
        if (value || value === 0) {
            history.push(`/${menuIds[value]}`);
            setSelected(value);
        }
    };
    return (
        <div className={classes.root}>
            <AppBar position="static" color="default">
                {menu && !loading ? (
                    <Tabs
                        value={selected}
                        onChange={handleChange}
                        scrollable
                        scrollButtons="auto"
                        indicatorColor="primary"
                        textColor="primary"
                    >
                        {menu.map(item => (
                            <Tab
                                key={item.id}
                                classes={{ root: classes.tab }}
                                label={<span className={classes.tabLabel}>{item.title}</span>}
                                selected={false}
                            />
                        ))}
                    </Tabs>
                ) : (
                    <Fragment />
                )}
            </AppBar>
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
