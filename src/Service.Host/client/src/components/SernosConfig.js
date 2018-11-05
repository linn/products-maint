import React, { Component } from 'react';
import { FormGroup, Input, Container, Row, Col, Button, Alert } from 'reactstrap';
import { Loading } from './common/Loading';
import { makeNumber } from '../helpers/utilities';

class SernosConfig extends Component {
    constructor(props) {
        super(props);
        this.state = { dropdownOpen: false, sernosConfig: this.props.sernosConfig, editStatus: this.props.editStatus || 'view' };

        this.toggle = this.toggle.bind(this);
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

    handleStartOnChange(e) {
        this.setState({ sernosConfig: { ...this.state.sernosConfig, startOn: e.currentTarget.value } });
    }

    toggle() {
        this.setState(prevState => ({
            dropdownOpen: !prevState.dropdownOpen
        }));
    }

    render() {
        const { sernosConfig, loading, errorMessage } = this.props;

        if (loading || !sernosConfig) {
            return( 
                errorMessage?
                <Container>
                <Row>
                    <Col sm={8}>
                        <Alert style={{ marginTop: "15px" }} color="warning" >
                        <strong>{errorMessage}</strong>
                        </Alert >
                    </Col>
                </Row>                
                </Container>
        :  <Loading />);
        }

        return (
            <div className="container">
                <Container>
                        <FormGroup row>
                            <Col sm={3} />
                            <Col sm={4}>
                                <h2>Sernos Config</h2>
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Col sm={3}>
                                <div className="pull-right">Name</div>
                            </Col>
                            <Col sm={3} id="sernos-config-name">
                                {this.creating()
                                    ? <div><Input type="text" onChange={(e) => this.handleNameChange(e)} placeholder="Name" defaultValue={sernosConfig.name}></Input></div>
                                    : sernosConfig.name
                                }
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Col  sm={3}>
                                <div className="pull-right">Description</div>
                            </Col>
                            <Col sm={6}>
                                {this.editing() || this.creating()
                                    ? <Input type="text" placeholder="Description" onChange={(e) => this.handleDescriptionChange(e)} defaultValue={sernosConfig.description}></Input>
                                    : sernosConfig.description
                                }
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Col xs={3} >
                                <div className="pull-right">Serial Numbered</div>
                            </Col>
                            <Col xs={8}>
                                {this.editing() || this.creating()
                                ? <Input type="checkbox" checked={this.state.sernosConfig.serialNumbered === 'Y'} onChange={ch => this.handleSerialNumberedChange(ch.target.checked)}>
                                </Input>
                                    : <div>{sernosConfig.serialNumbered}</div>
                                }
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Col sm={3}>
                                <div className="pull-right">Number Of Serial Nos</div>
                            </Col>
                            <Col sm={6}>
                                {this.editing() || this.creating()
                                    ? <Input type="number" placeholder="Number Of Sernos" onChange={(e) => this.handleNumberOfSernosChange(e)} defaultValue={sernosConfig.numberOfSernos}></Input>
                                    : sernosConfig.numberOfSernos
                                }
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Col sm={3}>
                                <div className="pull-right">Number Of Boxes</div>
                            </Col>
                            <Col sm={6}>
                                {this.editing() || this.creating()
                                    ? <Input type="number" placeholder="Number Of Boxes" onChange={(e) => this.handleNumberOfBoxesChange(e)} defaultValue={sernosConfig.numberOfBoxes}></Input>
                                    : sernosConfig.numberOfBoxes
                                }
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Col sm={3}>
                                <div className="pull-right">Start On</div>
                            </Col>
                            <Col sm={6}>
                                {this.editing() || this.creating()
                                ?
                    <div>
                        <Input value={this.state.sernosConfig.startOn} type="select" name="select" id="exampleSelect" onChange={e => this.handleStartOnChange(e)}>
                            <option value="">-</option>
                            <option value="Any">Any</option>
                            <option value="Odd">Odd</option>
                            <option value="Even">Even</option>
                        </Input></div>
                                : sernosConfig.startOn
                                }
                            </Col>
                    </FormGroup>
                    <Row>
                        <Col sm={3} />
                        <Col sm={4}>
                            {this.editing() || this.creating()
                                ? <div>
                                        <Button color="link" id="cancel-button" onClick={() => this.handleCancelClick()}>Cancel</Button>
                                        <Button color="primary" id="save-button" className="pull-right" color="primary" type="submit" onClick={() => this.handleSaveClick()}>Save</Button></div>
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

export default SernosConfig;

