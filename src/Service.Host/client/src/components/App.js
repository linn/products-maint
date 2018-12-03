import React, { Component } from 'react';
import { Grid, Row, Col } from 'react-bootstrap';
import { Link } from 'react-router-dom';

class App extends Component {
    render() {
        return (
            <Grid fluid={false}>
                <h2>Products</h2>
                <Row>
                    <Col xs={12}>
                        <Link style={{ display: 'block' }} to="/products/maint/sernos-configs">Sernos Config Types</Link>
                    </Col>
                </Row >
                <Row>
                    <Col xs={12}>
                        <h2>Reports</h2>
                        <Link style={{ display: 'block' }} to="/products/reports/sales-article-ean-codes">Sales Article Ean Codes Report</Link>
                        <Link style={{ display: 'block' }} to="/products/reports/carton-details/report">Carton Details Report</Link>
                        <Link style={{ display: 'block' }} to="/products/reports/product-ranges">Product Ranges Report</Link>
                    </Col>
                </Row >
                <Row>
                    <Col xs={12}>
                        <h2>Utilities</h2>
                        <Link style={{ display: 'block' }} to="/products/maint/tariffs">Tariffs</Link>
                        <Link style={{ display: 'block' }} to="/products/maint/sa-core-types">Sales Article Core Types</Link>
                    </Col>
                </Row >
            </Grid >
        );
    }
}

export default App;