import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Grid } from '@material-ui/core';
import {
    SaveBackCancelButtons,
    InputField,
    Loading,
    Title,
    ErrorCard
} from '@linn-it/linn-form-components-library';
import Page from '../containers/Page';

class SaCoreType extends Component {
    constructor(props) {
        super(props);
        this.handleFieldChange = this.handleFieldChange.bind(this);
        this.state = {
            editStatus: 'view',
            saCoreType: null
        };
    }

    static getDerivedStateFromProps(props) {
        if (props.saCoreType) {
            return { saCoreType: props.saCoreType };
        }
        return null;
    }

    handleSaveClick = () => {
        const { saCoreTypeId, updateSaCoreType } = this.props;
        updateSaCoreType(saCoreTypeId, { ...this.state }.saCoreType);
        this.setState({ editStatus: 'view' });
    };

    handleCancelClick = () => {
        const { saCoreType } = this.props;
        this.setState({ saCoreType });
        this.setState({ editStatus: 'view' });
    };

    handleAddClick = () => {
        const { addSaCoreType } = this.props;
        const { saCoreType } = this.state;
        addSaCoreType(saCoreType);
        this.setState({ editStatus: 'view' });
    };

    handleBackClick = () => {
        this.setState({ editStatus: 'view' });
        const { history } = this.props;
        history.push('/products/maint/sa-core-types');
    };

    creating() {
        const { editStatus } = this.props;
        return editStatus === 'create';
    }

    editing() {
        const { editStatus } = this.state;
        return editStatus === 'edit';
    }

    viewing() {
        const { editStatus } = this.state;
        return editStatus === 'view';
    }

    handleFieldChange(propertyName, val) {
        this.setState(prevState => ({
            saCoreType: {
                ...prevState.saCoreType,
                [propertyName]: val
            },
            editStatus: 'edit'
        }));
    }

    render() {
        const { loading, errorMessage } = this.props;
        const { saCoreType } = this.state;
        if (loading || !saCoreType) {
            return <Loading />;
        }

        return (
            <Page>
                <Grid container spacing={24}>
                    <Grid item xs={12}>
                        {this.creating() ? (
                            <Title text="Add Sales Article Core Type" />
                        ) : (
                            <Title text="Sales Article Core Type Details" />
                        )}
                    </Grid>
                    {errorMessage && (
                        <Grid item xs={12}>
                            <ErrorCard errorMessage={errorMessage} />
                        </Grid>
                    )}
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
                        <SaveBackCancelButtons
                            saveDisabled={
                                !this.editing() ||
                                (!saCoreType.coreType || saCoreType.coreType.length === 0)
                            }
                            saveClick={this.creating() ? this.handleAddClick : this.handleSaveClick}
                            cancelClick={this.handleCancelClick}
                            backClick={this.handleBackClick}
                        />
                    </Grid>
                </Grid>
            </Page>
        );
    }
}

SaCoreType.defaultProps = {
    saCoreType: {},
    addSaCoreType: null,
    updateSaCoreType: null,
    loading: null,
    errorMessage: '',
    saCoreTypeId: null
};

SaCoreType.propTypes = {
    saCoreType: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    saCoreTypeId: PropTypes.string,
    updateSaCoreType: PropTypes.func,
    addSaCoreType: PropTypes.func,
    loading: PropTypes.bool
};

export default SaCoreType;
