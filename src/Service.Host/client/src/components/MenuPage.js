import React from 'react';
import PropTypes from 'prop-types';
import { withStyles, createMuiTheme, MuiThemeProvider } from "@material-ui/core/styles";
import MenuList from './MenuList';
import Divider from '@material-ui/core/Divider';
import { Paper } from '@material-ui/core';

const styles = theme => ({
    root: {
        position: "relative",
        width: "100%",
        font: "14px!important"
    },
    paper: {
        height: "auto",
        backgroundColor: "rgba(244, 244, 244, 1)"
    },
    control: {
        padding: '0px'
    },
});

const theme = createMuiTheme({
    overrides: {
      MuiTypography: {
        root: {
          fontSize: "14px !important",
        },
       
      },
      MuiListItem: {
        root: {
          paddingTop: "0px !important",
          paddingBottom: "0px !important"
        },
       
      },
      MuiList: {
        root: {
          padding: "0px !important",
          paddingTop: "0px !important",
          paddingBottom: "0px !important"
        },
      }
    }
  });

const MenuPage = ({ classes, lists }) => (
    lists.length >= 1 ?
    (
        <div className = {classes.root}> 
         <MuiThemeProvider theme={theme}>
            {lists.map((list, i) => (
                <Paper key={i} className={classes.paper}> {list.map((item, index) => (
                    <div key={index + item.title}>
                        <MenuList key={item.title} title={item.title} entries={item.items} />
                        <Divider />
                    </div>))}
                </Paper>
            ))}
            </MuiThemeProvider>
        </div>
    )
    : 
    <span />
);

MenuPage.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(MenuPage);
