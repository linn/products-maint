import React, { Component } from 'react';
import { Grid, Row, Col } from 'react-bootstrap';

class App extends Component {
    render() {
        return (
            <Grid fluid={false}>
            <h2>Products</h2>
                <Row>
                    <Col xs={12}>
                    </Col>
                </Row >
            </Grid >
        );
    }
}

export default App;