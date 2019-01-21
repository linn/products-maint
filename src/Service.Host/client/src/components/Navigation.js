import React, { Component } from 'react';
import Breadcrumbs from '../containers/Breadcrumbs';
import Dashboard from './Dashboard';

class Navigation extends Component {

    render() {
        const breadcrumbs = <Breadcrumbs />;
        return ( <div>
            <Dashboard breadcrumbs={breadcrumbs} /> 
          
            </div>
        );
    }
}

export default Navigation;
