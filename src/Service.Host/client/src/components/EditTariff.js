import React, { Component } from 'react';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import { withStyles } from '@material-ui/core/styles';
import { SaveCancelButtons, Loading } from '@linn-it/linn-form-components-library';
import { getSelfHref } from '../helpers/utilities';
import TextInput from './common/forms/TextInput';

const styles = theme => ({
    paper: {
        padding: theme.spacing.unit * 6,
        marginTop: 40
    }
});

class EditTariff extends Component {

    constructor(props) {
        super(props);
        this.state = { tariff: this.props.tariff, editStatus: this.props.editStatus || 'view' };

        this.handleSaveClick = this.handleSaveClick.bind(this);
        this.handleCancelClick = this.handleCancelClick.bind(this);
        this.handleTariffFieldChange = this.handleTariffFieldChange.bind(this);
    }

    editing() {
        return this.state.editStatus === 'edit';
    }

    creating() {
        return this.state.editStatus === 'create';
    }

    handleSaveClick() {
        const { addTariff, updateTariff, id, history } = this.props;

        if (this.creating()) {
            addTariff(this.state.tariff).then(() => history.push("/products/maint/tariffs"));
        } else if (this.editing()) {
            let tariffUrl = getSelfHref(this.state.tariff);
            updateTariff(id, this.state.tariff).then(() => history.push(tariffUrl));
        }
    }

    handleCancelClick() {
        const { history } = this.props;
        if (this.creating()) {
            history.push('/products/maint/tariffs');
        } else if (this.editing()) {
            history.push(getSelfHref(this.state.tariff));
        } 
    }

    handleTariffFieldChange(propertyName, newValue) {
        this.setState({ tariff: { ...this.state.tariff, [propertyName]: newValue } });
    }

    render() {
        const { tariff, loading, classes } = this.props;

        if (loading || !tariff) {
            return (
                <div className="linn-container">
                    <Grid container spacing={24}>
                        <Paper className={classes.paper}>
                            <Loading />
                        </Paper>
                    </Grid>
                </div>
            );
        }

        return (
            <div className="linn-container">
                <Grid container spacing={24}>
                    <Grid item sm="12">
                        <Paper className={classes.paper}>
                            <div>
                                <TextInput
                                    label="Tariff Code"
                                    value={tariff.tariffCode}
                                    placeholder="Tariff Code"
                                    width="half"
                                    propertyName="tariffCode"
                                    changeState={this.handleTariffFieldChange}
                                />
                            </div>

                            <div>
                                <TextInput
                                    label="Description"
                                    value={tariff.description}
                                    placeholder="Description"
                                    width="full"
                                    propertyName="description"
                                    changeState={this.handleTariffFieldChange}
                                />
                            </div>

                            <div>
                                <TextInput
                                    label="US Tariff Code"
                                    value={tariff.usTariffCode}
                                    width="half"
                                    placeholder="US Tariff Code"
                                    propertyName="usTariffCode"
                                    changeState={this.handleTariffFieldChange}
                                />
                            </div>

                            <div>
                                <TextInput
                                    label="Duty"
                                    value={tariff.duty}
                                    placeholder="Duty"
                                    width="short"
                                    suffix="%"
                                    type="number"
                                    propertyName="duty"
                                    changeState={this.handleTariffFieldChange}
                                />
                            </div>

                            <div>
                                <TextInput
                                    label="Date Invalid"
                                    value={tariff.dateInvalid}
                                    placeholder="Date Invalid"
                                    width="short"
                                    type="date"
                                    propertyName="dateInvalid"
                                    changeState={this.handleTariffFieldChange}
                                />
                            </div>

                            <SaveCancelButtons
                                saveClick={this.handleSaveClick}
                                cancelClick={this.handleCancelClick}        
                            />
                        </Paper>
                    </Grid>
                </Grid>
            </div>
        );
    }
}

export default withStyles(styles)(EditTariff);