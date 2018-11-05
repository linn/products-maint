import React, { Component } from 'react';
import { PageHeader, Grid, Checkbox, Row, Col, Button } from 'react-bootstrap';

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
                <Grid>
                    <PageHeader>
                        <small>Product Ranges Report Options</small>
                    </PageHeader>

                    <Row>
                        <Col xs={10}>
                            <Checkbox checked={this.state.includePhasedOut} onChange={ch => this.handlePhaseOutChange(ch.target.checked)}>
                                Include phased out
                            </Checkbox>
                        </Col>
                    </Row>
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

export default ProductRangesOptions;