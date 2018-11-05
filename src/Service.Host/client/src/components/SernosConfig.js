import React, { Component } from 'react';
import { FormGroup, ControlLabel, FormControl, Grid, Row, Col, Button, Alert, Checkbox, DropdownButton, MenuItem } from 'react-bootstrap';
import { Loading } from './common/Loading';
import { makeNumber } from '../helpers/utilities';

class SernosConfig extends Component {
    constructor(props) {
        super(props);
        this.state = { sernosConfig: this.props.sernosConfig, editStatus: this.props.editStatus || 'view' };
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
        this.setState({ sernosConfig: this.props.sernosConfig, editStatus: 'edit' });
    }

    handleCancelClick() {
        const { sernosConfig, history, resetSernosConfig } = this.props;
        if (this.creating()) {
            resetSernosConfig();
            history.push('/products/maint');
        } else if (this.editing()) {
            resetSernosConfig();
            this.setState({ sernosConfig, editStatus: 'view' });
        }
    }

    handleSaveClick() {
        const { sernosConfigId, addSernosConfig, updateSernosConfig } = this.props;
        if (this.creating()) {
            addSernosConfig(this.state.sernosConfig);
        } else if (this.editing()) {
            updateSernosConfig(sernosConfigId, this.state.sernosConfig);
        }
    }

    handleBackClick() {
        const { history } = this.props;
        history.push('/products/maint');
    }

    handleNameChange(e) {
        this.setState({ sernosConfig: { ...this.state.sernosConfig, name: e.target.value } });
    }

    handleDescriptionChange(e) {
        this.setState({ sernosConfig: { ...this.state.sernosConfig, description: e.target.value } });
    }

    handleNumberOfSernosChange(e) {
        this.setState({ sernosConfig: { ...this.state.sernosConfig, numberOfSernos: makeNumber(e.target.value) } });
    }

    handleNumberOfBoxesChange(e) {
        this.setState({ sernosConfig: { ...this.state.sernosConfig, numberOfBoxes: makeNumber(e.target.value) } });
    }

    handleSerialNumberedChange(checked) {
        this.setState({ sernosConfig: { ...this.state.sernosConfig, serialNumbered: checked ? 'Y' : 'N' } });
    }

    handleStartOnChange(selected) {
        this.setState({ sernosConfig: { ...this.state.sernosConfig, startOn: selected } });
    }

    render() {
        const { sernosConfig, loading, errorMessage } = this.props;

        if (loading || !sernosConfig) {
            return( 
                errorMessage?
                <Grid>
                <Row>
                    <Col sm={8}>
                        <Alert style={{ marginTop: "15px" }} bsStyle="warning" >
                        <strong>{errorMessage}</strong>
                        </Alert >
                    </Col>
                </Row>                
                </Grid>
        :  <Loading />);
        }

        return (
            <div className="container">
                <Grid>
                    <Row>
                        <FormGroup controlId="header">
                            <Col sm={3} />
                            <Col componentClass={ControlLabel} sm={4}>
                                <h2>Sernos Config</h2>
                            </Col>
                        </FormGroup>
                    </Row>
                    <Row>
                        <FormGroup controlId="name" className="container">
                            <Col componentClass={ControlLabel} sm={3}>
                                <div className="pull-right">Name</div>
                            </Col>
                            <Col sm={3} id="sernos-config-name">
                                {this.creating()
                                    ? <div><FormControl type="text" onChange={(e) => this.handleNameChange(e)} placeholder="Name" defaultValue={sernosConfig.name}></FormControl></div>
                                    : sernosConfig.name
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
                                    ? <FormControl type="text" placeholder="Description" onChange={(e) => this.handleDescriptionChange(e)} defaultValue={sernosConfig.description}></FormControl>
                                    : sernosConfig.description
                                }
                            </Col>
                        </FormGroup>
                    </Row>
                    <Row>
                        <FormGroup controlId="serial-numbered" className="container">
                            <Col xs={3} componentClass={ControlLabel}>
                                <div className="pull-right">Serial Numbered</div>
                            </Col>
                            <Col xs={9}>
                                {this.editing() || this.creating()
                                    ? <Checkbox checked={this.state.sernosConfig.serialNumbered === 'Y'} onChange={ch => this.handleSerialNumberedChange(ch.target.checked)}>
                                    </Checkbox>
                                    : <div>{sernosConfig.serialNumbered}</div>
                                }
                            </Col>
                        </FormGroup>
                    </Row>
                    <Row>
                        <FormGroup controlId="number-of-sernos" className="container">
                            <Col componentClass={ControlLabel} sm={3}>
                                <div className="pull-right">Number Of Serial Nos</div>
                            </Col>
                            <Col sm={6}>
                                {this.editing() || this.creating()
                                    ? <FormControl type="number" placeholder="Number Of Sernos" onChange={(e) => this.handleNumberOfSernosChange(e)} defaultValue={sernosConfig.numberOfSernos}></FormControl>
                                    : sernosConfig.numberOfSernos
                                }
                            </Col>
                        </FormGroup>
                    </Row>
                    <Row>
                        <FormGroup controlId="number-of-boxes" className="container">
                            <Col componentClass={ControlLabel} sm={3}>
                                <div className="pull-right">Number Of Boxes</div>
                            </Col>
                            <Col sm={6}>
                                {this.editing() || this.creating()
                                    ? <FormControl type="number" placeholder="Number Of Boxes" onChange={(e) => this.handleNumberOfBoxesChange(e)} defaultValue={sernosConfig.numberOfBoxes}></FormControl>
                                    : sernosConfig.numberOfBoxes
                                }
                            </Col>
                        </FormGroup>
                    </Row>
                    <Row>
                        <FormGroup controlId="start-on" className="container">
                            <Col componentClass={ControlLabel} sm={3}>
                                <div className="pull-right">Start On</div>
                            </Col>
                            <Col sm={6}>
                                {this.editing() || this.creating()
                                    ?
                                    <DropdownButton title={this.state.sernosConfig.startOn ? this.state.sernosConfig.startOn : '-'}
                                        key={sernosConfig.startOn}
                                        id={sernosConfig.startOn}
                                        onSelect={e => this.handleStartOnChange(e)}>
                                        <MenuItem eventKey="Any">Any</MenuItem>
                                        <MenuItem eventKey="Odd">Odd</MenuItem>
                                        <MenuItem eventKey="Even">Even</MenuItem>
                                    </DropdownButton>
                                    : sernosConfig.startOn
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
                            {errorMessage ?
                                <Alert style={{marginTop: "15px"}}  bsStyle="warning">
                                    <strong>{errorMessage}</strong>
                                </Alert>
                                : '' }
                        </Col>
                    </Row>
                </Grid>
            </div>
        );
    }
}

export default SernosConfig;

