import React, { Component } from 'react';
import { PageHeader, Grid, Checkbox, Row, Col, Button } from 'react-bootstrap';

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
                <Grid>
                    <PageHeader>
                        <small>Ean Codes of Sales Articles Report Options</small>
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
                            <Checkbox checked={this.state.cartonisedOnly} onChange={ch => this.handleCartonisedOnlyChange(ch.target.checked)}>
                                Cartonised Only
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

export default EanCodesOptions;