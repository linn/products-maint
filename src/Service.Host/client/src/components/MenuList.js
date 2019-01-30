import React from "react";
import PropTypes from "prop-types";
import { withStyles, createMuiTheme, MuiThemeProvider } from "@material-ui/core/styles";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemText from "@material-ui/core/ListItemText";
import Collapse from "@material-ui/core/Collapse";
import ExpandLess from "@material-ui/icons/ExpandLess";
import ExpandMore from "@material-ui/icons/ExpandMore";

const styles = theme => ({
  root: {
    width: "100%",
    fontSize: '12px !important'

  },
  nested: {
    paddingLeft: theme.spacing.unit * 4,
  },
  titles: {
    paddingLeft: theme.spacing.unit * 4,
    fontSize: '12px !important',
    fontWeight: "bold !important",
  },
  noPad: {
    padding: "0px !important"
  }
});

const theme = createMuiTheme({
  overrides: {
    MuiTypography: {
      root: {
        fontSize: "12px !important",
      },
     
    },
  }
});

class MenuList extends React.Component {

  state = {
    open: false
  };

  handleClick = () => {
    this.setState(state => ({ open: !state.open }));
  };

  render() {
    const { classes, title, entries } = this.props;
    return (
      <List
        component="nav"
        className={classes.root}
      >

        <ListItem button onClick={this.handleClick} >
          <ListItemText> {title}</ListItemText>
          {this.state.open ? <ExpandLess /> : <ExpandMore />}
        </ListItem>

        <Collapse in={this.state.open} timeout="auto" unmountOnExit className={classes.noPad}>
        <MuiThemeProvider theme={theme}>
          <List component="div" disablePadding>
            {entries.map((entry, index) => (
              entry.showInMenu ? (
                <a key={entry.title} href={ entry.href} className={classes.nested}>
                  <ListItem key={entry.title + index} button className={classes.nested}  >
                    <ListItemText  primary={entry.title} />
                  </ListItem> </a>) : <span key={entry.title}/>
            ))}
          </List>
          </MuiThemeProvider>
        </Collapse>
      </List>
    );
  }
}

MenuList.propTypes = {
  classes: PropTypes.object.isRequired
};

export default withStyles(styles)(MenuList);