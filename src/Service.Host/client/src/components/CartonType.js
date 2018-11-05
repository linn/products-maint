import React, { Component } from 'react';
import { FormGroup, Container, Row, Col, Button, Alert, Label, Input, Form } from 'reactstrap';
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
        const { cartonType, loading, errorMessage } = this.props;

        if (loading || !cartonType) {
            return <Loading />;
        }

        return (
            <div className="container">
                <Container>
                    <Row>
                            <Col sm="3" />
                            <Col sm="7">
                                <h2>Carton Type</h2>
                            </Col>
                    </Row>
 
                        <FormGroup row>
                            <Col sm={3}>
                                <div className="pull-right">Name</div>
                            </Col>
                            <Col sm={9} >
                                <div id="carton-type-name">
                                {this.creating()
                                    ? <div><Input type="text" onChange={(e) => this.handleNameChange(e)} placeholder="Name" defaultValue={cartonType.name}></Input></div>
                                    : <Label> {cartonType.name} </Label>
                                    }
                                </div>
                            </Col>
                        </FormGroup>
      
                        <FormGroup row>
                            <Col sm={3}>
                                <div className="pull-right">Description</div>
                            </Col>
                            <Col sm={6}>
                                {this.editing() || this.creating()
                                    ? <Input type="text" placeholder="Description" onChange={(e) => this.handleDescriptionChange(e)} defaultValue={cartonType.description}></Input>
                                    : cartonType.description
                                }
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Col sm={3}>
                                <div className="pull-right">Width</div>
                            </Col>
                            <Col sm={6}>
                                {this.editing() || this.creating()
                                    ? <Input type="number" placeholder="Width" onChange={(e) => this.handleWidthChange(e)} defaultValue={cartonType.width}></Input>
                                    : cartonType.width
                                }
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Col sm={3}>
                                <div className="pull-right">Height</div>
                            </Col>
                            <Col sm={6}>
                                {this.editing() || this.creating()
                                    ? <Input type="number" placeholder="Description" onChange={(e) => this.handleHeightChange(e)} defaultValue={cartonType.height}></Input>
                                    : cartonType.height
                                }
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Col sm={3}>
                                <div className="pull-right">Depth</div>
                            </Col>
                            <Col sm={6}>
                                {this.editing() || this.creating()
                                    ? <Input type="number" placeholder="Description" onChange={(e) => this.handleDepthChange(e)} defaultValue={cartonType.depth}></Input>
                                    : cartonType.depth
                                }
                            </Col>
                        </FormGroup>
                    <Row>
                        <Col sm={3} />
                        <Col sm={4}>
                            {this.editing() || this.creating()
                                ? <div><Button color="link" id="cancel-button" onClick={() => this.handleCancelClick()}>Cancel</Button>
                                    <Button color="primary" id="save-button" className="pull-right" type="submit" onClick={() => this.handleSaveClick()}>Save</Button></div>
                                : <div><Button color="link" id="back-button" onClick={() => this.handleBackClick()}>Back</Button>
                                       <Button color="primary" outline id="edit-button" className="pull-right" onClick={() => this.handleEditClick()}>Edit</Button></div>}
                        </Col>
                    </Row>
                    <Row>
                        <Col sm={3} />
                        <Col sm={4}>
                            {errorMessage ?
                                <Alert style={{marginTop: "15px"}} color="warning">
                                    <strong>{errorMessage}</strong>
                                </Alert>
                                : '' }
                        </Col>
                    </Row>
                </Container>
            </div>
        );
    }
}

export default CartonType;

