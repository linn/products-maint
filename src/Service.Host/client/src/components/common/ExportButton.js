import React, { Component } from 'react';
import { OverlayTrigger, Tooltip, Button, Glyphicon } from 'react-bootstrap';

export default class ExportButton extends Component {
    render() {
        const href = this.props.href;

        return (
            <OverlayTrigger placement="top" overlay={<Tooltip id="tooltip1">Download report as CSV file</Tooltip>}>
                <Button style={{ marginTop: '25px', marginBottom: '10px' }} href={href}><Glyphicon className="text-muted" glyph="export" /> Export</Button>
            </OverlayTrigger>
        );
    }
}