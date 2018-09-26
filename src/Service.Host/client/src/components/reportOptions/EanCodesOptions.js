import React, { Component } from 'react';
import { PageHeader, Grid, Checkbox, Row, Col, Button } from 'react-bootstrap';

class EanCodesOptions extends Component {
    constructor(props) {
        super(props);
        this.state = {
            includePhasedOut: props.prevOptions ? props.prevOptions.includePhasedOut : false
        };
    }

    handlePhaseOutChange(checked) {
        this.setState({ includePhasedOut: checked });
    }

    handleClick(product) {
        const { history } = this.props;

        history.push(
            {
                pathname: `/products/reports/sales-article-ean-codes/report`,
                search: `?includePhasedOut=${this.state.includePhasedOut}`
            }
        );
    }

    getChecked() {
        if (this.state.includePhasedOut) {
            return 'checked';
        }
        return '';
    }

    render() {
        return (
            <Grid>
                <PageHeader>
                    <small>Ean Codes of Sales Articles</small>
                </PageHeader>
                <Row>
                    <Col xs={10}>
                        <h3>Select Options</h3>
                    </Col>
                </Row>
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
        );
    }
}

export default EanCodesOptions;