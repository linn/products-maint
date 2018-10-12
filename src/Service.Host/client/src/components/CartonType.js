﻿import React, { Component } from 'react';
import { FormGroup, ControlLabel, FormControl, Grid, Row, Col, Button } from 'react-bootstrap';
import { Loading } from './common/Loading';

class CartonType extends Component {
    constructor(props) {
        super(props);
        this.state = { cartonType: this.props.cartonType, editStatus: this.props.editStatus || 'view' };
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
        this.setState({ cartonType: {}, editStatus: 'edit' });
    }

    handleCancelClick() {
        const { cartonType, history } = this.props;
        if (this.creating()) {
            history.push('/products/reports/carton-details/report');
        } else if (this.editing()) {
            this.setState({ cartonType, editStatus: 'view' });
        }
    }

    handleSaveClick() {
        if (this.creating()) {
            this.setState({ editStatus: 'view' });
            this.props.addCartonType(this.state.cartonType);
        } else if (this.editing()) {
            this.setState({ editStatus: 'view' });
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

    render() {
        const { cartonType, loading } = this.props;

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
                            <Col sm={3}>
                                {this.editing() || this.creating()
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
                        <Col sm={3} />
                        <Col sm={4}>
                            {this.editing() || this.creating()
                                ? <div><Button bsStyle="link" onClick={() => this.handleCancelClick()}>Cancel</Button> <Button className="pull-right" bsStyle="primary" type="submit" onClick={() => this.handleSaveClick()}>Save</Button></div>
                                : <div><Button bsStyle="link" onClick={() => this.handleBackClick()}>Back</Button> <Button className="pull-right" onClick={() => this.handleEditClick()}>Edit</Button></div>}
                        </Col>
                    </Row>
                </Grid>
            </div>
        );
    }
}

export default CartonType;

