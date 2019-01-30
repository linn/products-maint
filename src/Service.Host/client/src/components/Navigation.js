import React, { Component } from 'react';
import Breadcrumbs from '../containers/Breadcrumbs';
import Navbar from './Navbar';

class Navigation extends Component {

    render() {
        const breadcrumbs = <Breadcrumbs />;
        return ( <Navbar />
        );
    }
}

export default Navigation;
