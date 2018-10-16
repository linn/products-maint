import React, { Component } from 'react';
import { FormGroup, ControlLabel, FormControl, Grid, Row, Col, Button, Alert } from 'react-bootstrap';
import { Loading } from './common/Loading';
import { makeNumber } from '../helpers/utilities';

class CartonType extends Component {
    constructor(props) {
        super(props);
        this.state = { cartonType: this.props.cartonType, editStatus: this.props.editStatus || 'view' };
    }

    componentWillReceiveProps(nextProps) {
        this.setState({ editStatus: nextProps.editStatus });
    }

    viewing() {
        return this.state.editStatus === 'view';
    }

    editing() {
        return this.state.editStatus === 'edit';
    }

    creating() {
        return this.state.editStatus === 'create';
    }

    handleEditClick() {
        this.setState({ cartonType: this.props.cartonType, editStatus: 'edit' });
    }

    handleCancelClick() {
        const { cartonType, history, resetCartonType } = this.props;
        if (this.creating()) {
            resetCartonType();
            history.push('/products/reports/carton-details/report');
        } else if (this.editing()) {
            resetCartonType();
            this.setState({ cartonType, editStatus: 'view' });
        }
    }

    handleSaveClick() {
        const { cartonTypeId, addCartonType, updateCartonType } = this.props;
        if (this.creating()) {
            addCartonType(this.state.cartonType);
        } else if (this.editing()) {
            updateCartonType(cartonTypeId, this.state.cartonType);
        }
    }

    handleBackClick() {
        const { history } = this.props;
        history.push('/products/reports/carton-details/report');
    }

    handleNameChange(e) {
        this.setState({ cartonType: { ...this.state.cartonType, name: e.target.value } });
    }

    handleDescriptionChange(e) {
        this.setState({ cartonType: { ...this.state.cartonType, description: e.target.value } });
    }

    handleWidthChange(e) {
        this.setState({ cartonType: { ...this.state.cartonType, width: makeNumber(e.target.value) } });
    }

    handleDepthChange(e) {
        this.setState({ cartonType: { ...this.state.cartonType, depth: makeNumber(e.target.value) } });
    }

    handleHeightChange(e) {
        this.setState({ cartonType: { ...this.state.cartonType, height: makeNumber(e.target.value) } });
    }

    render() {
        const { cartonType, loading, fetchError } = this.props;

        if (loading || !cartonType) {
            return <Loading />;
        }

        return (
            <div className="container">
                <Grid>
                    <Row>
                        <FormGroup controlId="header">
                            <Col sm={3} />
                            <Col componentClass={ControlLabel} sm={4}>
                                <h2>Carton Type</h2>
                            </Col>
                        </FormGroup>
                    </Row>
                    <Row>
                        <FormGroup controlId="name" className="container">
                            <Col componentClass={ControlLabel} sm={3}>
                                <div className="pull-right">Name</div>
                            </Col>
                            <Col sm={3} id="carton-type-name">
                                {this.creating()
                                    ? <div><FormControl type="text" onChange={(e) => this.handleNameChange(e)} placeholder="Name" defaultValue={cartonType.name}></FormControl></div>
                                    : cartonType.name
                                }
                            </Col>
                        </FormGroup>
                    </Row>
                    <Row>
                        <FormGroup controlId="description" className="container">
                            <Col componentClass={ControlLabel} sm={3}>
                                <div className="pull-right">Description</div>
                            </Col>
                            <Col sm={6}>
                                {this.editing() || this.creating()
                                    ? <FormControl type="text" placeholder="Description" onChange={(e) => this.handleDescriptionChange(e)} defaultValue={cartonType.description}></FormControl>
                                    : cartonType.description
                                }
                            </Col>
                        </FormGroup>
                    </Row>
                    <Row>
                        <FormGroup controlId="width" className="container">
                            <Col componentClass={ControlLabel} sm={3}>
                                <div className="pull-right">Width</div>
                            </Col>
                            <Col sm={6}>
                                {this.editing() || this.creating()
                                    ? <FormControl type="number" placeholder="Width" onChange={(e) => this.handleWidthChange(e)} defaultValue={cartonType.width}></FormControl>
                                    : cartonType.width
                                }
                            </Col>
                        </FormGroup>
                    </Row>
                    <Row>
                        <FormGroup controlId="height" className="container">
                            <Col componentClass={ControlLabel} sm={3}>
                                <div className="pull-right">Height</div>
                            </Col>
                            <Col sm={6}>
                                {this.editing() || this.creating()
                                    ? <FormControl type="number" placeholder="Description" onChange={(e) => this.handleHeightChange(e)} defaultValue={cartonType.height}></FormControl>
                                    : cartonType.height
                                }
                            </Col>
                        </FormGroup>
                    </Row>
                    <Row>
                        <FormGroup controlId="depth" className="container">
                            <Col componentClass={ControlLabel} sm={3}>
                                <div className="pull-right">Depth</div>
                            </Col>
                            <Col sm={6}>
                                {this.editing() || this.creating()
                                    ? <FormControl type="number" placeholder="Description" onChange={(e) => this.handleDepthChange(e)} defaultValue={cartonType.depth}></FormControl>
                                    : cartonType.depth
                                }
                            </Col>
                        </FormGroup>
                    </Row>
                    <Row>
                        <Col sm={3} />
                        <Col sm={4}>
                            {this.editing() || this.creating()
                                ? <div><Button id="cancel-button" bsStyle="link" onClick={() => this.handleCancelClick()}>Cancel</Button> <Button id="save-button" className="pull-right" bsStyle="primary" type="submit" onClick={() => this.handleSaveClick()}>Save</Button></div>
                                : <div><Button id="back-button" bsStyle="link" onClick={() => this.handleBackClick()}>Back</Button> <Button id="edit-button" className="pull-right" onClick={() => this.handleEditClick()}>Edit</Button></div>}
                        </Col>
                    </Row>
                    <Row>
                        <Col sm={3} />
                        <Col sm={4}>
                            {fetchError ? fetchError.errors ?
                                <Alert style={{marginTop: "15px"}}  bsStyle="warning">
                                    <strong>{fetchError.errors[0]}</strong>
                                </Alert>
                                : '' : ''}
                        </Col>
                    </Row>
                </Grid>
            </div>
        );
    }
}

export default CartonType;

