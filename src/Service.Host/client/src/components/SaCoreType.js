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
        width: "90%",
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
    }

    componentWillReceiveProps(nextProps) {
        this.setState({ editStatus: nextProps.editStatus, saCoreType: nextProps.saCoreType });
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

    handleCoreTypeChange = (e) => {
        this.setState({ saCoreType: { ...this.state.saCoreType, coreType: makeNumber(e.target.value, null) } });
    }

    handleDescriptionChange = (e) => {
        this.setState({ saCoreType: { ...this.state.saCoreType, description: e.target.value } });
    }

    handleDateInvalidChange = (e) => {
        this.setState({ saCoreType: { ...this.state.saCoreType, dateInvalid: e.target.value } });
    }

    handleLookAheadDaysChange = (e) => {
        this.setState({ saCoreType: { ...this.state.saCoreType, lookAheadDays: makeNumber(e.target.value, null) } });
    }

    handleTriggerLevelChange = (e) => {
        this.setState({ saCoreType: { ...this.state.saCoreType, triggerLevel: makeNumber(e.target.value, null) } });
    }

    handleSortOrderChange = (e) => {

        this.setState({ saCoreType: { ...this.state.saCoreType, sortOrder: makeNumber(e.target.value, null) } });
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
                            value={this.state.saCoreType.coreType}
                            onChange={(e) => this.handleCoreTypeChange(e)}
                        />
                    </Grid>
                    <Grid item xs={6}  >
                        <FormField
                            propertyName="description"
                            config={{
                                label: "Description",
                                disabled: false,
                            }}
                            value={this.state.saCoreType.description}
                            onChange={(e) => this.handleDescriptionChange(e)}
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <FormField
                            config={{
                                type: "number",
                                label: "Look Ahead Days",
                            }}
                            value={this.state.saCoreType.lookAheadDays}
                            onChange={(e) => this.handleLookAheadDaysChange(e)}
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <FormField
                            config={{
                                type: "number",
                                label: "Trigger Level",
                            }}
                            value={this.state.saCoreType.triggerLevel}
                            onChange={(e) => this.handleTriggerLevelChange(e)}
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <FormField
                            config={{
                                type: "number",
                                label: "Sort Order",
                            }}
                            value={this.state.saCoreType.sortOrder}
                            onChange={(e) => this.handleSortOrderChange(e)}
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <FormField
                            config={{
                                label: "Date Invalid",
                                type: "date"
                            }}
                            value={this.creating() ? "" : moment(this.state.saCoreType.dateInvalid).format('YYYY-MM-DD')}
                            onChange={(e) => this.handleDateInvalidChange(e)}
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
