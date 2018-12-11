import React, { Component } from 'react';
import { Grid, Row, Col } from 'react-bootstrap';
import Breadcrumbs from '../containers/Breadcrumbs';
import Dashboard from './Dashboard';

class Navigation extends Component {

    render() {
        //const breadcrumbs = <Breadcrumbs />;
        return ( <div>
            <Dashboard /> 
            <Grid className="header" fluid={false}>
                <Row>
                    <Col xs={12}>
                        <Breadcrumbs />
                    </Col>
                </Row>
            </Grid> 
            </div>
        );
    }
}

export default Navigation;
