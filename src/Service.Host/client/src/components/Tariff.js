import React, { Component } from 'react';
import { Grid, Row } from 'react-bootstrap';
import { Loading } from './common/Loading';

class Tariff extends Component {

    render() {
        const { tariff, loading } = this.props;

        if (loading || !tariff) {
            return (
                <div>
                    <Grid fluid={false}>
                        <Row>
                            <Loading />
                        </Row>
                    </Grid>
                </div>
            );
        }

        return (
            <Grid fluid={false}>
                <h2>{tariff.tariffCode}</h2>
                <div style={{ marginBottom: '10px' }}>
                    <strong>Description:</strong> {tariff.description}
                </div>
                <div style={{ marginBottom: '10px' }}>
                    <strong>US Tariff Code:</strong> {tariff.usTariffCode}
                </div>
                <div style={{ marginBottom: '10px' }}>
                    <strong>Date Invalid:</strong> {tariff.dateInvalid}
                </div>
                <div style={{ marginBottom: '10px' }}>
                    <strong>Duty %:</strong> {tariff.duty}
                </div>
            </Grid>
        );
    }
}

export default Tariff;