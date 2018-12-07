import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import { Loading } from './common/Loading';
import { makeNumber } from '../helpers/utilities'
import moment from 'moment';
import Grid from '@material-ui/core/Grid';
import FormField from './common/FormField'
import SaveCancelButtons from './common/SaveCancelButtons'
import BackButton from './common/BackButton';


const styles = theme => ({
    root: {
        width: "70%",
        margin: "0 auto"

    },
    grid: {
        width: "100%",
        margin: "0 auto"
    }
});

class SaCoreType extends Component {
    
    constructor(props) {
        super(props);
        this.state = { saCoreType: this.props.saCoreType, editStatus: this.props.editStatus || "view" };

        this.handleFieldChange = this.handleFieldChange.bind(this);
    }

    componentWillReceiveProps(nextProps) {
        this.setState({ editStatus: nextProps.editStatus, saCoreType: nextProps.saCoreType });
    }

    // Status
    viewing() {
        return this.state.editStatus === 'view';
    }

    editing() {
        return this.state.editStatus === 'edit';
    }

    creating() {
        return this.state.editStatus === 'create';
    }

    // Button event Handlers
    handleSaveClick = () => {
        const { saCoreTypeId, updateSaCoreType } = this.props;
        updateSaCoreType(saCoreTypeId, this.state.saCoreType);
    }

    handleResetClick = () => {
        this.setState({ saCoreType: this.props.saCoreType })
    }

    handleAddClick = () => {
        const { addSaCoreType } = this.props;
        addSaCoreType(this.state.saCoreType);
    }

    handleCancelClick = () => {
        const { history } = this.props;
        history.push('/products/maint/sa-core-types');
    }

    // Fiels Change Event Handler
    handleFieldChange(propertyName, newValue) {
        this.setState({ saCoreType: { ...this.state.saCoreType, [propertyName]: newValue } });
    }

    render() {
        const { saCoreType, loading, errorMessage, addSaCoreType, classes } = this.props;

        if (loading || !saCoreType) {
            return (
                <Loading />);
        }

        return (
            <div className={classes.root}>
                <Grid container spacing={24}>
                    <Grid item xs={12} >
                        <h2 className={classes.h2}>
                            {this.creating() ?
                                <span> Add Sales Article Core Type </span> :
                                <span>Sales Article Core Type Details </span>}
                        </h2>
                    </Grid>
                    <Grid item xs={6}  >
                        <FormField
                            config={{
                                type: "number",
                                label: "Core Type",
                                disabled: !this.creating(),
                                required: true
                            }}
                            propertyName="coreType"
                            value={this.state.saCoreType.coreType}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={6}  >
                        <FormField
                            propertyName="description"
                            config={{
                                label: "Description",
                                disabled: false,
                            }}
                            propertyName="description"
                            value={this.state.saCoreType.description}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <FormField
                            config={{
                                type: "number",
                                label: "Look Ahead Days",
                            }}
                            propertyName="lookAheadDays"
                            value={this.state.saCoreType.lookAheadDays}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <FormField
                            config={{
                                type: "number",
                                label: "Trigger Level",
                            }}
                            propertyName="triggerLevel"
                            value={this.state.saCoreType.triggerLevel}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <FormField
                            config={{
                                type: "number",
                                label: "Sort Order",
                            }}
                            propertyName="sortOrder"
                            value={this.state.saCoreType.sortOrder}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <FormField
                            config={{
                                label: "Date Invalid",
                                type: "date"
                            }}
                            propertyName="dateInvalid"
                            value={this.creating() ? null : moment(this.state.saCoreType.dateInvalid).format('YYYY-MM-DD')}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <BackButton
                            backClick={this.handleCancelClick}
                        />
                        <SaveCancelButtons
                            disabled={JSON.stringify(this.state.saCoreType) === JSON.stringify(saCoreType)}
                            saveClick={this.creating() ? this.handleAddClick : this.handleSaveClick}
                            cancelClick={this.handleResetClick}
                        />
                    </Grid>
                </Grid>
            </div>
        );
    }
};

SaCoreType.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(SaCoreType);
