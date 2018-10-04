import React, { Component } from 'react';
import { Grid, Row, ListGroup, ListGroupItem, FormGroup, InputGroup, FormControl } from 'react-bootstrap';
import { Loading } from './common/Loading';
import { getSelfHref } from '../helpers/utilities';

class Tariffs extends Component {
    state = { searchTerm: '' }

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

                    <FormGroup>
                        <FormControl autoFocus value={this.state.searchTerm} onChange={e => this.handleSearchTermChange(e)} type="text" placeholder="Search by tariff code or description" style={{ width: '50%' }} ></FormControl>
                    </FormGroup>

                    <ListGroup>
                        {tariffs.map((tariff, i) => (
                            <ListGroupItem key={i} onClick={() => this.handleDiscountSchemeClick(tariff)}>{tariff.tariffCode} {tariff.description}</ListGroupItem>
                        ))}
                    </ListGroup>
                </Grid>
            </div>
        );
    }

    handleSearchTermChange(e) {
        const { fetchTariffs } = this.props;
        const searchTerm = e.target.value;

        this.setState({ searchTerm });

        fetchTariffs(searchTerm);
    }

    handleTariffClick(tariff) {
        const tariffUri = getSelfHref(tariff);
        const { history } = this.props;
        history.push(`${tariffUri}`);
    }
}

export default Tariffs;