import React, { Component } from 'react';
import { PageHeader, Grid, Row, Col, Button } from 'react-bootstrap';

class EanCodesOptions extends Component {
    handleClick(product) {
        const { history } = this.props;

        history.push(
            {
                pathname: `/products/reports/sales-article-ean-codes`,
                search: `?go=true`
            }
        );
    }

    render() {
        const { parameters } = this.props;

        return (
            <Grid>
                <PageHeader>
                    <small>Ean Codes of Sales Articles</small>
                </PageHeader>
                <Row>
                    <Col xs={2}>
                      
                    </Col>
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