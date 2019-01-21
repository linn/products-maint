import React from "react";
import PropTypes from "prop-types";
import classNames from "classnames";
import { withStyles } from "@material-ui/core/styles";
import Drawer from "@material-ui/core/Drawer";
import CssBaseline from "@material-ui/core/CssBaseline";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import List from "@material-ui/core/List";
import Breadcrumbs from "../containers/Breadcrumbs";
import Divider from "@material-ui/core/Divider";
import IconButton from "@material-ui/core/IconButton";
import MenuIcon from "@material-ui/icons/Menu";
import ChevronLeftIcon from "@material-ui/icons/ChevronLeft";
import ChevronRightIcon from "@material-ui/icons/ChevronRight";
import MenuList from "./MenuList";

const drawerWidth = 200;
let menu;

const styles = theme => ({
    root: 
    {
        display: "flex",
        fontSize: "24px !important"
    },

    appBar: 
    {
        transition: theme.transitions.create(["margin", "width"], {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen,
    })
    },

    appBarShift: {
        width: `calc(100% - ${drawerWidth}px)`,
        marginLeft: drawerWidth,
        transition: theme.transitions.create(["margin", "width"], {
        easing: theme.transitions.easing.easeOut,
        duration: theme.transitions.duration.enteringScreen
    })
    },

    menuButton: {
        marginLeft: 0,
        marginRight: 0
    },

    hide: {
        display: "none"
    },

    drawer: {
        width: drawerWidth,
        flexShrink: 0
    },

    drawerPaper: {
        width: drawerWidth
    },

    // drawerHeader: {
    //     display: "flex",
    //     alignItems: "left",
    //     textAlign: "left",
    //     padding: "0 0px",
    //     ...theme.mixins.toolbar
    // },

    content: {
        flexGrow: 1,
        padding: theme.spacing.unit * 3,
        transition: theme.transitions.create("margin", {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen
        }),
        marginLeft: -drawerWidth
    },

    contentShift: {
        transition: theme.transitions.create("margin", {
        easing: theme.transitions.easing.easeOut,
        duration: theme.transitions.duration.enteringScreen
        }),
        marginLeft: 0
    }
});

class Dashboard extends React.Component 
{
    state = {
        open: false, 
    };
    
    constructor(props) {
        super(props);
        menu = require('./menu.json').sections;

        this.HandleMenuItemClick = this.HandleMenuItemClick.bind(this);
    }

    handleDrawerOpen = () => {
        this.setState({ open: true });
    };


    handleDrawerClose = () => {
        this.setState({ open: false });
    };

    getTopLevelMenu = () => {
        var topLevelStrings = menu.map(x => String(x.title));
        return topLevelStrings;
    }

    slugify = (title) => {
        var id = title.toLowerCase();
        id = id.replace("&", "-and-");
        return id;
    }

    HandleMenuItemClick = (text) => {
    };

    render() {
        const { classes, theme,  breadcrumbs } = this.props;
        const { open, selected } = this.state;

        return (
        <div className={classes.root}>
            <CssBaseline />
            <AppBar
                position="fixed"
                className={classNames(classes.appBar, {
                    [classes.appBarShift]: open
                })}>
            <Toolbar disableGutters={!open}>
                <IconButton
                color="inherit"
                aria-label="Open drawer"
                onClick={this.handleDrawerOpen}
                className={classNames(classes.menuButton, open && classes.hide)}
                >
                <MenuIcon />
                </IconButton>
                {breadcrumbs ? 
                            <Breadcrumbs {...this.props} /> : <span />}  
                
            </Toolbar>
            </AppBar>
            <Drawer
                className={classes.drawer}
                variant="persistent"
                anchor="left"
                open={open}
                classes={{
                    paper: classes.drawerPaper
                }} >
                <div className={classes.drawerHeader}>
                    <IconButton onClick={this.handleDrawerClose}>
                    Hide Menu
                    {theme.direction === "ltr" ? (
                        <ChevronLeftIcon />
                    ) : (
                        <ChevronRightIcon />
                    )}
                    </IconButton>
                </div>
                <Divider />
                    <List> 
                        {this.getTopLevelMenu().map((text, index) => (
                            <MenuList 
                                key={index}
                                title={text} 
                                list={menu[index].items} 
                                selected={this.state.selected}/>
                    ))} 
                    </List> 
            </Drawer>
            <main
                className={classNames(classes.content, {
                    [classes.contentShift]: open
                })}
                >
                <div className={classes.drawerHeader} />
            </main>
        </div>
        );
    }
}

Dashboard.propTypes = {
classes: PropTypes.object.isRequired,
theme: PropTypes.object.isRequired
};

export default withStyles(styles, { withTheme: true })(Dashboard);