import React, { Component } from 'react';
import { Loading } from '../common/Loading';
import { Grid, Row, Col, Table, OverlayTrigger, Tooltip, Button, Glyphicon } from 'react-bootstrap';
import config from '../../config';

class EanCodes extends Component {
    render() {
        const { xxx } = this.props;

        return (
            <div>
                <Grid fluid={false}>
                    <Row>
                        <Col xs={8}>
                            <h3>Sales Article Ean Codes</h3>
                        </Col>
                        <Col xs={2}>
                            <OverlayTrigger placement="top" overlay={<Tooltip id="tooltip1">Download report as CSV file</Tooltip>}>
                                <Button style={{ marginTop: '25px', marginBottom: '10px' }} href={`${config.appRoot}/`}><Glyphicon className="text-muted" glyph="export" /> Export</Button>
                            </OverlayTrigger>
                        </Col>
                    </Row>
                    <Row>
                        <Col xs={10}>
                            <Table>
                                <thead>
                                    <tr>
                                        <th style={{ width: '45%' }}></th>
                                        <th style={{ width: '20%' }}></th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </Table>
                        </Col>
                    </Row>
                </Grid>
            </div>
        );
    }
}

export default EanCodes;