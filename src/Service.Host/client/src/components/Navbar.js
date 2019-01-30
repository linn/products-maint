import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import Typography from '@material-ui/core/Typography';
import ClickAwayListener from '@material-ui/core/ClickAwayListener';
import MenuPage from "./MenuPage";

let topLevels;
let menu;

function TabContainer(props) {
    return (
        <Typography component="div">
            {props.children}
        </Typography>
    );
}

TabContainer.propTypes = {
    children: PropTypes.node.isRequired,
};

const styles = theme => ({
    root: {
        width: '100%',
        backgroundColor: theme.palette.background.paper,
        position: 'absolute',
        top: 0,
        zIndex: 1500
    },
    container: {
       
        backgroundColor: theme.palette.background.paper,
    },

    tab: {
        minWidth: 20,
       
    },

    tabRight: {
        minWidth: 20,
        position: "absolute",
        right: 0
        
    },

    tabLabel: {
        fontSize: '12px'
    }
});

class Navbar extends React.Component {
    state = {
        value: false,
    };

    constructor(props) {
        super(props);
        menu = require('./menu.json').sections;
        topLevels = menu.map(x => ({ id: x.id, title: x.title, link: x.links[0].href }));
    }

    handleChange = (event, value) => {

        var id = this.slugify(topLevels[value].title);
        var section = menu.filter(x => x.id === id);
        var columns = section[0].columns;
        var categoriesListArray = [];

        columns.forEach(function (column) {
            categoriesListArray.push(column.categories);
        });

        var lists = [];

        categoriesListArray.forEach(function (categoriesList) {
            lists.push(categoriesList);
        });

        this.setState({
            value: value,
            lists: lists
        });
    };

    slugify = (title) => {
        var id = title.toLowerCase();
        id = id.replace("&", "-and-");
        return id;
    }

    handleClick = () => {
        this.setState({ selected: false });
    };

    handleClickAway = () => {
        this.setState({
            value: false,
        });
    };

    render() {
        const { classes } = this.props;
        const { value } = this.state;

        return (
            <div className={classes.root}>
                <ClickAwayListener onClickAway={this.handleClickAway}>
                    <div>
                        <AppBar position="static" color="default">
                            <Tabs
                                value={value}
                                onChange={this.handleChange}
                                scrollable
                                scrollButtons="auto"
                                indicatorColor="primary"
                                textColor="primary"
                            >
                                {topLevels.map((item, index) => (
                                    <Tab 
                                        key={index} 
                                        classes={index == topLevels.length -1 ? { root: classes.tabRight} : {root: classes.tab}} 
                                        label={<span className={classes.tabLabel}>{item.title}</span>} 
                                        selected={false} 
                                        />
                                ))}
                            </Tabs>
                        </AppBar>
                        {this.state.lists && (this.state.value || this.state.value === 0) ?
                            <TabContainer className={classes.container}>
                                <MenuPage lists={this.state.lists} />
                            </TabContainer> : false}
                    </div>
                </ClickAwayListener>
            </div>
        );
    }
}

Navbar.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Navbar);
