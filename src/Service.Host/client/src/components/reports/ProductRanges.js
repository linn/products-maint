import React, { Component } from 'react';
import { Loading } from '../common/Loading';
import { Container, Row, Col } from 'reactstrap';
import Table from '../common/Table';

class ProductRanges extends Component {
    render() {
        const { reportData, loading, options } = this.props;
        const optionsTitle = !options.includePhasedOut || options.includePhasedOut === 'false' ? 'Live ' : '';
        return (
            <div>
                <Container fluid={false}>
                    <Row>
                        <Col xs={8}>
                            <h3>{optionsTitle}Product Ranges</h3>
                        </Col>
                        <Col xs={2}>
                        </Col>
                    </Row>
                    <Row>
                        {loading ? <Loading /> : ''}
                        <Col xs={10}>
                            <Table size="sm" reportData={reportData} showTotals={false} placeholderRows={10} placeholderColumns={3} showRowTitles={false} showTitle={false} />
                        </Col>
                    </Row>
                </Container>
            </div>
        );
    }
}

export default ProductRanges;