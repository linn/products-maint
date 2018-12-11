import React from "react";
import PropTypes from "prop-types";
import { withStyles } from "@material-ui/core/styles";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemText from "@material-ui/core/ListItemText";
import Collapse from "@material-ui/core/Collapse";
import ExpandLess from "@material-ui/icons/ExpandLess";
import ExpandMore from "@material-ui/icons/ExpandMore";
import { Link } from 'react-router-dom';

const styles = theme => ({
  root: {
    width: "100%",
    maxWidth: 360,
  },
  nested: {
    paddingLeft: theme.spacing.unit * 4,
  },
  titles: {
    paddingLeft: theme.spacing.unit * 4,
    fontWeight: "bold !important",
  },
});

class MenuList extends React.Component {
  constructor(props) {
    super(props);
  }

  state = {
  };

  onClick = () => {
    this.setState(state => ({ open: !state.open }));
    this.props.handleClick();
  };

  render() {
    const { classes, title, list} = this.props;

    return (
      <div>
        <ListItem 
          button key={title} 
          selected={this.props.selected === title} 
          onClick={() => {
            this.setState(state => ({ open: !state.open }));
          }} >
          <Link style={{ fontSize: '18px' }} to={"#"}>{title}</Link>
          {this.state.open ? <ExpandLess /> : <ExpandMore />}
        </ListItem>
        
        <Collapse in={this.state.open} timeout="auto" unmountOnExit>
          <List component="div" disablePadding>
            {list.map((entry, index) => (
              entry.showInMenu ? 
              (
                <Link style={{ fontSize: '14px' }}   to={entry.href}>
                  <ListItem button className={classes.nested}  >
                    <ListItemText primary={entry.title} />
                  </ListItem>
                </Link>) 
              : <span />
            ))}
          </List>
        </Collapse>
      </div>
    );
  }
}

MenuList.propTypes = {
  classes: PropTypes.object.isRequired
};

export default withStyles(styles)(MenuList);
