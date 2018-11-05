import React, { Component } from 'react';
import { Container, Input, Row, Col, Button } from 'reactstrap';

class EanCodesOptions extends Component {
    constructor(props) {
        super(props);
        this.state = {
            includePhasedOut: props.prevOptions ? props.prevOptions.includePhasedOut : false,
            cartonisedOnly: props.prevOptions ? props.prevOptions.cartonisedOnly : true
        };
    }

    handlePhaseOutChange(checked) {
        this.setState({ includePhasedOut: checked });
    }

    handleCartonisedOnlyChange(checked) {
        this.setState({ cartonisedOnly: checked });
    }

    handleClick() {
        const { history } = this.props;

        history.push(
            {
                pathname: `/products/reports/sales-article-ean-codes/report`,
                search: `?includePhasedOut=${this.state.includePhasedOut}&cartonisedOnly=${this.state.cartonisedOnly}`
            }
        );
    }

    render() {
        return (
            <div className="container">
                <Container>
                    <h2>
                        <small>Ean Codes of Sales Articles Report Options</small>
                    </h2>
                    <Row>
                        <Col xs={10}>
                            <Input type="checkbox" checked={this.state.includePhasedOut} onChange={ch => this.handlePhaseOutChange(ch.target.checked)}>
                            </Input> Include phased out
                        </Col>
                    </Row>
                    <Row>
                        <Col xs={10}>
                            <Input type="checkbox" checked={this.state.cartonisedOnly} onChange={ch => this.handleCartonisedOnlyChange(ch.target.checked)}>
                            </Input> Cartonised Only
                        </Col>
                    </Row>
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

export default EanCodesOptions;