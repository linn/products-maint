import React, { Component } from 'react';
import { Container, Row, Col, Button } from 'reactstrap';

class CartonDetailsOptions extends Component {
    handleClick() {
        const { history } = this.props;

        history.push(
            {
                pathname: `/products/reports/carton-details/report`
            }
        );
    }

    render() {
        return (
            <div className="container">
                <Container>
                    <h2>
                        <small>Carton Details Report</small>
                    </h2>

                    <Row>
                        <Col xs={10}>
                            <Button color="primary" onClick={() => this.handleClick()}>
                                Run Report
                            </Button>
                        </Col>
                    </Row>
                </Container>
            </div>
        );
    }
}

export default CartonDetailsOptions;