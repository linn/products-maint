import React, { Component } from 'react';
import { Container, Row, Col } from 'reactstrap';
import Breadcrumbs from '../containers/Breadcrumbs';

class Navigation extends Component {

    render() {
        return (
            <Container className="header" fluid={false}>
                <Row>
                    <Col xs={12}>
                        <Breadcrumbs />
                    </Col>
                </Row>
            </Container>
        );
    }
}

export default Navigation;
