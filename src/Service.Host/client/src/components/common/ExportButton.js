import React, { Component } from 'react';
import { Tooltip, Button } from 'reactstrap';

export default class ExportButton extends Component {
    constructor(props) {
        super(props);

        this.toggle = this.toggle.bind(this);
        this.state = {
            tooltipOpen: false
        };
    }

    toggle() {
        this.setState({
            tooltipOpen: !this.state.tooltipOpen
        });
    }

    render() {
        const href = this.props.href;

        return (
            <span>
                <Button color="secondary" outline id="export-button" style={{ marginTop: '25px', marginBottom: '10px' }} href={href}> Export</Button>
                <Tooltip isOpen={this.state.tooltipOpen} target="export-button" toggle={this.toggle}>Download report as CSV file</Tooltip>
            </span>
        );
    }
}