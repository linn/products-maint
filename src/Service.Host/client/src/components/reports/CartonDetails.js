import React, { Component } from 'react';
import { Loading } from '../common/Loading';
import { Grid, Row, Col } from 'react-bootstrap';
import Table from '../common/Table';
import { Link } from 'react-router-dom';

class CartonDetails extends Component {
    render() {
        const { reportData, loading } = this.props;

        return (
            <div>
                <Grid fluid={false}>
                    <Row>
                        <Col xs={8}>
                            <h3>Carton Details</h3>
                        </Col>
                    </Row>
                    <Row>
                        <Col xs={10}>
                            <Link style={{ display: 'block' }} to="/products/maint/carton-types/create">Create new carton type</Link>
                        </Col>
                    </Row>
                    <Row>
                        {loading ? <Loading /> : ''}
                        <Col xs={10}>
                            <Table reportData={reportData} showTotals={false} placeholderRows={10} placeholderColumns={3} showTitle={false} />
                        </Col>
                    </Row>
                </Grid>
            </div>
        );
    }
}

export default CartonDetails;