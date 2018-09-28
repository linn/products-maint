import React, { Component } from 'react';
import { PageHeader, Grid, Checkbox, Row, Col, Button } from 'react-bootstrap';

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
                <Grid>
                    <PageHeader>
                        <small>Carton Details Report</small>
                    </PageHeader>

                    <Row>
                        <Col xs={10}>
                            <Button bsClass="btn" onClick={() => this.handleClick()}>
                                Run Report
                            </Button>
                        </Col>
                    </Row>
                </Grid>
            </div>
        );
    }
}

export default CartonDetailsOptions;