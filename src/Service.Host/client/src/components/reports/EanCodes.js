import React, { Component } from 'react';
import { Loading } from '../common/Loading';
import { Grid, Row, Col, OverlayTrigger, Tooltip, Button, Glyphicon } from 'react-bootstrap';
import config from '../../config';
import Table from '../common/Table';

class EanCodes extends Component {
    render() {
        const { reportData, loading, options } = this.props;

        return (
            <div>
                <Grid fluid={false}>
                    <Row>
                        <Col xs={8}>
                            <h3>Sales Article Ean Codes</h3>
                        </Col>
                        <Col xs={2}>
                            <OverlayTrigger placement="top" overlay={<Tooltip id="tooltip1">Download report as CSV file</Tooltip>}>
                                <Button style={{ marginTop: '25px', marginBottom: '10px' }} href={`${config.appRoot}/products/reports/sales-article-ean-codes/export?includePhasedOut=${options.includePhasedOut}`}><Glyphicon className="text-muted" glyph="export" /> Export</Button>
                            </OverlayTrigger>
                        </Col>
                    </Row>
                    <Row>
                        {loading ? <Loading /> : ''}
                        <Col xs={10}>
                            <Table reportData={reportData} showTotals={false} placeholderRows={10} placeholderColumns={3} showTitle={false} />
                        </Col>
                    </Row>
                </Grid>
            </div>
        );
    }
}

export default EanCodes;