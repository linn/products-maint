import React, { Component } from 'react';
import { Loading } from '../common/Loading';
import { Container, Row, Col } from 'reactstrap';
import Table from '../common/Table';
import { Link } from 'react-router-dom';

class CartonDetails extends Component {
    render() {
        const { reportData, loading } = this.props;

        return (
            <div>
                <Container fluid={false}>
                    <Row>
                        <Col xs={8}>
                            <h3>Carton Details</h3>
                            {loading ? <Loading /> : ''}
                        </Col>
                    </Row>
                    <Row>
                        <Col xs={10}>
                            <Link style={{ display: 'block' }} to="/products/maint/carton-types/create">Create new carton type</Link>
                        </Col>
                    </Row>
                    <Row>
                        <Col xs={10}>
                            <Table reportData={reportData} showTotals={false} placeholderRows={10} placeholderColumns={3} showTitle={false} />
                        </Col>
                    </Row>
                </Container>
            </div>
        );
    }
}

export default CartonDetails;