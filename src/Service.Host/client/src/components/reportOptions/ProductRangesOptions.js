import React, { Component } from 'react';
import { Container, Input, Row, Col, Button } from 'reactstrap';

class ProductRangesOptions extends Component {
    constructor(props) {
        super(props);
        this.state = {
            includePhasedOut: props.prevOptions ? props.prevOptions.includePhasedOut : false
        };
    }

    handlePhaseOutChange(checked) {
        this.setState({ includePhasedOut: checked });
    }

    handleClick() {
        const { history } = this.props;

        history.push(
            {
                pathname: `/products/reports/product-ranges/report`,
                search: `?includePhasedOut=${this.state.includePhasedOut}`
            }
        );
    }

    render() {
        return (
            <div className="container">
                <Container>
                    <h2>
                        <small>Product Ranges Report Options</small>
                    </h2>

                    <Row>
                        <Col xs={10}>
                            <Input type="checkbox" checked={this.state.includePhasedOut} onChange={ch => this.handlePhaseOutChange(ch.target.checked)}>
                            </Input> Include phased out
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

export default ProductRangesOptions;