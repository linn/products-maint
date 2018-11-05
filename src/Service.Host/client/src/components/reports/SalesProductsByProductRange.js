﻿import React, { Component } from 'react';
import { Loading } from '../common/Loading';
import { Container, Row, Col } from 'reactstrap';
import Table from '../common/Table';
import { Link } from 'react-router-dom';

class SalesProductsByProductRange extends Component {
    render() {
        const { reportData, loading, options } = this.props;
        const optionsTitle = !options.includePhasedOut || options.includePhasedOut === 'false' ? 'Live s' : 'S';
        return (
            <div>
                <Container fluid={false}>
                    <Row>
                        <Col xs={8}>
                            <h3>{optionsTitle}ales products for product range {options.productRangeName}</h3>
                            {loading ? <Loading /> : ''}
                        </Col>
                        <Col xs={2}>
                            <Link style={{ display: 'block', marginTop: '20px' }} to={`/products/reports/product-ranges/report?includePhasedOut=${options.includePhasedOut}`}>Back To Ranges</Link>
                        </Col>
                    </Row>
                    <Row>
                        <Col xs={10}>
                            <Table reportData={reportData} showTotals={false} placeholderRows={10} placeholderColumns={3} showRowTitles={false} showTitle={false} />
                        </Col>
                    </Row>
                </Container>
            </div>
        );
    }
}

export default SalesProductsByProductRange;