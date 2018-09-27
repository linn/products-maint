import React, { Component } from 'react';
import { Grid, Row, ListGroup, ListGroupItem } from 'react-bootstrap';
import { Loading } from './common/Loading';
import { getSelfHref } from '../helpers/utilities';

class Tariffs extends Component {
    render() {
        const { tariffs, loading } = this.props;

        if (loading || !tariffs) {
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
            <div>
                <Grid fluid={false}>
                    <h2>Tariffs</h2>
                    <ListGroup>
                        {tariffs.map((tariff, i) => (
                            <ListGroupItem key={i} onClick={() => this.handleDiscountSchemeClick(tariff)}>{tariff.tariffCode}</ListGroupItem>
                        ))}
                    </ListGroup>
                </Grid>
            </div>
        );
    }

    handleTariffClick(tariff) {
        const tariffUri = getSelfHref(tariff);
        const { history } = this.props;
        history.push(`${tariffUri}`);
    }
}

export default Tariffs;