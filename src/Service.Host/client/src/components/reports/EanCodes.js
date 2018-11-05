import React, { Component } from 'react';
import { Loading } from '../common/Loading';
import { Container, Row, Col } from 'reactstrap';
import Table from '../common/Table';
import ExportButton from '../common/ExportButton';

class EanCodes extends Component {
    render() {
        const { reportData, loading, options, config } = this.props;
        const optionsTitle = options.cartonisedOnly && options.cartonisedOnly !== 'false' ? '(Cartonised products only)' : '';
        const href =
            `${config.appRoot}/products/reports/sales-article-ean-codes/export?includePhasedOut=${options.includePhasedOut}&cartonisedOnly=${options.cartonisedOnly}`;

        return (
            <div>
                <Container fluid={false}>
                    <Row>
                        <Col xs={8}>
                            <h3>Sales Article Ean Codes {optionsTitle}</h3>
                            {loading ? <Loading /> : ''}
                        </Col>
                        <Col xs={2}>
                            <ExportButton href={href} />
                        </Col>
                    </Row>
                    <Row>
                        <Col xs={10}>
                            <Table reportData={reportData} showTotals={false} placeholderRows={10} placeholderColumns={3} showTitle={false} />
                        </Col>
                    </Row>
                </Container>
            </div>
        );
    }
}

export default EanCodes;