import React, { Component } from 'react';
import { Container, Row, Col } from 'reactstrap';
import { Link } from 'react-router-dom';

class App extends Component {
    render() {
        return (
            <Container fluid={false}>
            <h2>Products</h2>
                <Row>
                    <Col xs={12}>
                        <h2>Reports</h2>
                        <Link style={{ display: 'block' }} to="/products/reports/sales-article-ean-codes">Sales Article Ean Codes Report</Link>
                        <Link style={{ display: 'block' }} to="/products/reports/carton-details/report">Carton Details Report</Link>
                        <Link style={{ display: 'block' }} to="/products/reports/product-ranges">Product Ranges Report</Link>
                    </Col>
                </Row >
            </Container >
        );
    }
}

export default App;