import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';

let topLevels;
const menu = require('./menu.json').sections;

const styles = {
    root: {
        width: '100%',
        position: 'absolute',
        top: 0,
        zIndex: 1500
    },

    tab: {
        minWidth: 20
    },

    tabLabel: {
        fontSize: '12px'
    }
};

class Navbar extends React.Component {
    state = {
        value: false
    };

    constructor(props) {
        super(props);
        topLevels = menu.map(item => ({
            id: item.id,
            title: item.title,
            link: item.links[0].href
        }));
    }

    handleChange = (event, value) => {
        const { history } = this.props;
        history.push(`/${topLevels[value].id}`);
        this.setState({
            value
        });
    };

    slugify = title => {
        let id = title.toLowerCase();
        id = id.replace('&', '-and-');
        return id;
    };

    render() {
        const { classes } = this.props;
        const { value } = this.state;

        return (
            <div className={classes.root}>
                <AppBar position="static" color="default">
                    <Tabs
                        value={value}
                        onChange={this.handleChange}
                        scrollable
                        scrollButtons="auto"
                        indicatorColor="primary"
                        textColor="primary"
                    >
                        {topLevels.map(item => (
                            <Tab
                                key={item.id}
                                classes={{ root: classes.tab }}
                                label={<span className={classes.tabLabel}>{item.title}</span>}
                                selected={false}
                            />
                        ))}
                    </Tabs>
                </AppBar>
            </div>
        );
    }
}

Navbar.propTypes = {
    classes: PropTypes.shape({}).isRequired,
    history: PropTypes.shape({}).isRequired
};

export default withStyles(styles)(Navbar);
