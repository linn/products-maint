import React, { Component } from 'react';
import { FormGroup, ControlLabel, FormControl, Grid, Row, Col, Button } from 'react-bootstrap';
import { Loading } from './common/Loading';

class EditTariff extends Component {

    constructor(props) {
        super(props);
        this.state = { tariff: this.props.tariff, editStatus: this.props.editStatus || 'view' };
    }

    editing() {
        return this.state.editStatus === 'edit';
    }

    creating() {
        return this.state.editStatus === 'create';
    }

    handleSaveClick() {
        const { addTariff, updateTariff, tariffId } = this.props;
        if (this.creating()) {
            addTariff(this.state.tariff);
        } else if (this.editing()) {
            updateTariff(tariffId, this.state.tariff);
        }
    }


    handleCancelClick() {
        const { history } = this.props;
        if (this.creating()) {
            history.push('/products/maint/tariffs');
        }
    }

    handleDescriptionChange(e) {
        this.setState({ tariff: { ...this.state.tariff, description: e.target.value } });
    }

    handletariffCodeChange(e) {
        this.setState({ tariff: { ...this.state.tariff, tariffCode: e.target.value } });
    }

    handleusTariffCodeChange(e) {
        this.setState({ tariff: { ...this.state.tariff, usTariffCode: e.target.value } });
    }

    handleDutyChange(e) {
        this.setState({ tariff: { ...this.state.tariff, duty: e.target.value } });
    }

    handleDateInvalidChange(e) {
        this.setState({ tariff: { ...this.state.tariff, duty: e.target.value } });
    }

    render() {
        const { tariff, loading } = this.props;

        if (loading || !tariff) {
            return (
                <div>
                    <Grid fluid={false}>
                        <Row>
                            <Loading />
                        </Row>
                    </Grid>
                </div>
            );
        }

        return (
            <Grid fluid={false}>
                    <Row>
                    <FormGroup controlId="tariffCode" className="container">
                        <Col componentClass={ControlLabel} sm={3}>
                            <div className="pull-right">Tariff Code</div>
                        </Col>
                        <Col sm={6}>
                            <FormControl type="text" placeholder="Tariff Code" onChange={(e) => this.handletariffCodeChange(e)} defaultValue={tariff.tariffCode}></FormControl>
                        </Col>
                    </FormGroup>

                    <FormGroup controlId="description" className="container">
                        <Col componentClass={ControlLabel} sm={3}>
                            <div className="pull-right">Description</div>
                        </Col>
                        <Col sm={6}>
                            <FormControl type="text" placeholder="Description" onChange={(e) => this.handleDescriptionChange(e)} defaultValue={tariff.description}></FormControl>
                        </Col>
                    </FormGroup>

                    <FormGroup controlId="usTariffCode" className="container">
                        <Col componentClass={ControlLabel} sm={3}>
                            <div className="pull-right">Tariff Code</div>
                        </Col>
                        <Col sm={6}>
                            <FormControl type="text" placeholder="US Tariff Code" onChange={(e) => this.handleusTariffCodeChange(e)} defaultValue={tariff.usTariffCode}></FormControl>
                        </Col>
                    </FormGroup>

                    <FormGroup controlId="duty" className="container">
                        <Col componentClass={ControlLabel} sm={3}>
                            <div className="pull-right">Duty %</div>
                        </Col>
                        <Col sm={6}>
                            <FormControl type="text" placeholder="Duty %" onChange={(e) => this.handleDutyChange(e)} defaultValue={tariff.duty}></FormControl>
                        </Col>
                    </FormGroup>

                    <FormGroup controlId="dateInvalid" className="container">
                        <Col componentClass={ControlLabel} sm={3}>
                            <div className="pull-right">Date Invalid</div>
                        </Col>
                        <Col sm={6}>
                            <FormControl type="text" placeholder="Date Invalid" onChange={(e) => this.handleDateInvalidChange(e)} defaultValue={tariff.dateInvalid}></FormControl>
                        </Col>
                    </FormGroup>
                </Row>
                <Row>
                    <Col sm={3} />
                    <Col sm={4}>
                        <div>
                            <Button id="save-button" bsStyle="primary" type="submit" onClick={() => this.handleSaveClick()}>Save</Button>
                            <Button id="cancel-button" bsStyle="link" onClick={() => this.handleCancelClick()}>Cancel</Button>
                        </div>
                    </Col>
                </Row>
            </Grid>
        );
    }
}

export default EditTariff;