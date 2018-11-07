import React, { Component } from 'react';
import { Grid, Row, Button } from 'react-bootstrap';
import { Loading } from './common/Loading';
import { getSelfHref } from '../helpers/utilities';

class Tariff extends Component {

    handleEditClick() {
        const { history, tariff } = this.props;
        history.push(`${getSelfHref(tariff)}/edit`);
    }

    handleBackClick() {
        const { history } = this.props;
        history.push('/products/maint/tariffs');
    }

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
                <div>
                    <Button id="edit-button" bsStyle="primary" type="submit" onClick={() => this.handleEditClick()}>Edit</Button>
                    <Button id="back-button" bsStyle="link" onClick={() => this.handleBackClick()}>Back</Button>
                </div>
            </Grid>
        );
    }
}

export default Tariff;