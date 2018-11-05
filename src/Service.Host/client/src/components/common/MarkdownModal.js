import React, { Component } from 'react';
import { Modal, Button } from 'reactstrap';
import ReactMarkdown from 'react-markdown';

export class MarkdownModal extends Component {
    constructor(props) {
        super(props);
        this.state = { showModal: false, modalTitle: props.title ? props.title : 'Report Description', helpText: props.helpText };
    }

    componentWillReceiveProps(nextProps) {
        this.setState({ helpText: nextProps.helpText, modalTitle: nextProps.title ? nextProps.title : 'Report Description' });
    }

    closeModal() {
        this.setState({ showModal: false });
    }

    openModal() {
        this.setState({ showModal: true });
    }

    render() {
        return (
            this.state.helpText ?
                <div>
                    <Button style={{ opacity: 0.5 }} color="link" className="screen-only" onClick={() => this.openModal()}></Button>
                    <Modal show={this.state.showModal} onHide={() => this.closeModal()}>
                        <Modal.Header closeButton>
                            <Modal.Title>Report Description</Modal.Title>
                        </Modal.Header>
                        <Modal.Body>
                            <ReactMarkdown source={this.props.helpText} />
                        </Modal.Body>
                        <Modal.Footer>
                            <Button onClick={() => this.closeModal()}>Close</Button>
                        </Modal.Footer>
                    </Modal>
                </div> : null
        );
    }
}

export default MarkdownModal;