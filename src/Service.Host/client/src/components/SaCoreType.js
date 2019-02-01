import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import { Grid, Paper } from '@material-ui/core';
import {
    BackButton,
    SaveCancelButtons,
    InputField,
    Loading,
    Title
} from '@linn-it/linn-form-components-library';

const styles = () => ({
    root: {
        margin: 40,
        padding: 40
    },
    grid: {
        width: '100%',
        margin: '0 auto'
    }
});

class SaCoreType extends Component {
    constructor(props) {
        super(props);
        this.handleFieldChange = this.handleFieldChange.bind(this);
        this.state = {
            editStatus: 'view',
            saCoreType: null
        };
    }

    static getDerivedStateFromProps(props, state) {
        if (!state.saCoreType && props.saCoreType) {
            return { saCoreType: props.saCoreType };
        }
        return null;
    }

    handleSaveClick = () => {
        const { history } = this.props;
        const { saCoreTypeId, updateSaCoreType } = this.props;
        updateSaCoreType(saCoreTypeId, { ...this.state }.saCoreType);
        history.push('/products/maint/sa-core-types');
    };

    handleResetClick = () => {
        const { saCoreType } = this.props;
        this.setState({ saCoreType });
    };

    handleAddClick = () => {
        const { addSaCoreType } = this.props;
        addSaCoreType({ ...this.state }.saCoreType);
    };

    handleCancelClick = () => {
        const { history } = this.props;
        history.push('/products/maint/sa-core-types');
    };

    creating() {
        const { editStatus } = this.props;
        return editStatus === 'create';
    }

    editing() {
        const { editStatus } = this.props;
        return editStatus === 'edit';
    }

    edited() {
        const initState = { ...this.props }.saCoreType;
        const { saCoreType } = this.state;
        return JSON.stringify(initState) !== JSON.stringify(saCoreType);
    }

    viewing() {
        const { editStatus } = this.props;
        return editStatus === 'view';
    }

    handleFieldChange(propertyName, val) {
        this.setState(prevState => ({
            saCoreType: {
                ...prevState.saCoreType,
                [propertyName]: val
            }
        }));
    }

    render() {
        const { loading, classes } = this.props;
        const { saCoreType } = this.state;
        if (loading || !saCoreType) {
            return <Loading />;
        }

        return (
            <Paper className={classes.root}>
                <Grid container spacing={24}>
                    <Grid item xs={12}>
                        {this.creating() ? (
                            <Title text="Add Sales Article Core Type" />
                        ) : (
                            <Title text="Sales Article Core Type Details" />
                        )}
                    </Grid>
                    <Grid item xs={4}>
                        <InputField
                            fullWidth
                            disabled={!this.creating()}
                            value={saCoreType.coreType}
                            label="Core Type"
                            helperText={
                                !this.creating()
                                    ? 'This field cannot be changed'
                                    : 'This field is required'
                            }
                            onChange={this.handleFieldChange}
                            propertyName="coreType"
                        />
                    </Grid>
                    <Grid item xs={8}>
                        <InputField
                            value={saCoreType.description}
                            label="Description"
                            fullWidth
                            onChange={this.handleFieldChange}
                            propertyName="description"
                        />
                    </Grid>
                    <Grid item xs={3}>
                        <InputField
                            fullWidth
                            type="number"
                            value={saCoreType.lookAheadDays}
                            label="Look Ahead Days"
                            onChange={this.handleFieldChange}
                            propertyName="lookAheadDays"
                        />
                    </Grid>
                    <Grid item xs={3}>
                        <InputField
                            fullWidth
                            type="number"
                            value={saCoreType.triggerLevel}
                            label="Trigger level"
                            onChange={this.handleFieldChange}
                            propertyName="triggerLevel"
                        />
                    </Grid>
                    <Grid item xs={3}>
                        <InputField
                            fullWidth
                            type="number"
                            value={saCoreType.sortOrder}
                            label="Sort Order"
                            onChange={this.handleFieldChange}
                            propertyName="sortOrder"
                        />
                    </Grid>
                    <Grid item xs={3}>
                        <InputField
                            fullWidth
                            type="date"
                            value={saCoreType.dateInvalid}
                            label="Date Invalid"
                            onChange={this.handleFieldChange}
                            propertyName="dateInvalid"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <BackButton backClick={this.handleCancelClick} />
                        <SaveCancelButtons
                            disabled={
                                // disabled if not edited, or no coreType supplied
                                !this.edited() ||
                                (!saCoreType.coreType || saCoreType.coreType.length === 0)
                            }
                            saveClick={this.creating() ? this.handleAddClick : this.handleSaveClick}
                            cancelClick={this.handleResetClick}
                        />
                    </Grid>
                </Grid>
            </Paper>
        );
    }
}

SaCoreType.defaultProps = {
    saCoreType: {},
    addSaCoreType: null,
    updateSaCoreType: null,
    loading: null,
    saCoreTypeId: null
};

SaCoreType.propTypes = {
    classes: PropTypes.shape({}).isRequired,
    saCoreType: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    saCoreTypeId: PropTypes.string,
    updateSaCoreType: PropTypes.func,
    addSaCoreType: PropTypes.func,
    loading: PropTypes.bool
};

export default withStyles(styles)(SaCoreType);
