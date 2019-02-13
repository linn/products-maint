import React from 'react';
import fetch from 'node-fetch';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';

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

        this.state = {
            data: null
        };
    }

    componentDidUpdate() {
        fetch('http://app-sys.linn.co.uk/intranet/menu', {
            method: 'GET',
            credentials: 'include',
            headers: {
                Accept:
                    'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8',
                'Cache-Control': 'max-age=0',
                Cookie:
                    '_ga=GA1.3.1767863748.1541167458; __utmz=140191532.1541770320.1.1.utmcsr=google^|utmccn=(organic)^|utmcmd=organic^|utmctr=(not^%^20provided); __utma=140191532.1767863748.1541167458.1541770320.1542706318.2; _gcl_au=1.1.810918352.1547638067; _fbp=fb.2.1549460928862.2024121082; .ASPXAUTH=F3E23C4CC6C2D87E14415F5921B25DEB5785623766195FA0208AE56AF63C3352681A3FE481ECD5E0B89BE33522EA8BB951D2C3391EB3D48C76DD687997AE7BDF4EF74E3C05228EE8298689EBB7F9F7C778DC61EB1EBD2E9A65D0EC79397C9A3779BF442B3C2F18B1077CA00722049935C20DCE0E; _gid=GA1.3.2007555162.1549875004'
            }
        })
            .then(response => response.json())
            .then(data => this.setState({ data }));
    }

    handleChange = (event, value) => {
        const { history } = this.props;
        const { data } = this.state;
        const menuItems = data.sections.map(item => ({
            id: item.id,
            title: item.title,
            link: item.links[0].href
        }));
        history.push(`/${menuItems[value].id}`);

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
        const { value, data } = this.state;

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

                        {data
                            ? data.sections.map(item => (
                                  <Tab
                                      key={item.id}
                                      classes={{ root: classes.tab }}
                                      label={<span className={classes.tabLabel}>{item.title}</span>}
                                      selected={false}
                                  />
                              ))
                            : ''}

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
