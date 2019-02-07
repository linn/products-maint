﻿import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Grid } from '@material-ui/core';
import {
    SaveBackCancelButtons,
    InputField,
    Dropdown,
    Page,
    Loading,
    Title,
    ErrorCard
} from '@linn-it/linn-form-components-library';

class SernosConfig extends Component {
    constructor(props) {
        super(props);
        this.handleFieldChange = this.handleFieldChange.bind(this);
        this.state = {
            editStatus: 'view',
            sernosConfig: null
        };
    }

    static getDerivedStateFromProps(props, state) {
        if (!state.sernosConfig && props.sernosConfig) {
            return { sernosConfig: props.sernosConfig };
        }
        return null;
    }

    handleSaveClick = () => {
        const { sernosConfigId, updateSernosConfig } = this.props;
        updateSernosConfig(sernosConfigId, { ...this.state }.sernosConfig);
        this.setState({ editStatus: 'view' });
    };

    handleCancelClick = () => {
        const { sernosConfig } = this.props;
        this.setState({ sernosConfig });
        this.setState({ editStatus: 'view' });
    };

    handleAddClick = () => {
        const { addSernosConfig } = this.props;
        const { sernosConfig } = this.state;
        addSernosConfig(sernosConfig);
        this.setState({ editStatus: 'view' });
    };

    handleBackClick = () => {
        this.setState({ editStatus: 'view' });
        const { history } = this.props;
        history.push('/products/maint/sernos-configs');
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
        const { editStatus } = this.props;
        return editStatus === 'view';
    }

    handleFieldChange(propertyName, val) {
        this.setState(prevState => ({
            sernosConfig: {
                ...prevState.sernosConfig,
                [propertyName]: val
            },
            editStatus: 'edit'
        }));
    }

    render() {
        const { loading, errorMessage, history } = this.props;
        const { sernosConfig } = this.state;
        const startOnOptions = ['', 'Any', 'Odd', 'Even'];
        const serialNumberedOptions = ['Y', 'N'];
        if (loading || !sernosConfig) {
            return <Loading />;
        }

        return (
            <Page history={history}>
                <Grid container spacing={24} justify="center">
                    <Grid item xs={12}>
                        {this.creating() ? (
                            <Title text="Add Serial Number Configuration" />
                        ) : (
                            <Title text="Serial Number Configuration Details" />
                        )}
                    </Grid>
                    {errorMessage && (
                        <Grid item xs={12}>
                            <ErrorCard errorMessage={errorMessage} />
                        </Grid>
                    )}
                    <Grid item xs={6}>
                        <InputField
                            fullWidth
                            disabled={!this.creating()}
                            value={sernosConfig.name}
                            label="Name"
                            helperText={
                                !this.creating()
                                    ? 'This field cannot be changed'
                                    : 'This field is required'
                            }
                            onChange={this.handleFieldChange}
                            propertyName="name"
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <InputField
                            value={sernosConfig.description}
                            label="Description"
                            fullWidth
                            onChange={this.handleFieldChange}
                            propertyName="description"
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <Dropdown
                            value={sernosConfig.serialNumbered}
                            label="Serial Numbered"
                            fullWidth
                            items={serialNumberedOptions}
                            onChange={this.handleFieldChange}
                            propertyName="serialNumbered"
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <InputField
                            fullWidth
                            type="number"
                            value={sernosConfig.numberOfSernos}
                            label="Number of Serial Nos"
                            onChange={this.handleFieldChange}
                            propertyName="numberOfSernos"
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <InputField
                            fullWidth
                            type="number"
                            value={sernosConfig.numberOfBoxes}
                            label="Number of Serial Boxes"
                            onChange={this.handleFieldChange}
                            propertyName="numberOfBoxes"
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <Dropdown
                            value={sernosConfig.startOn}
                            label="Start On"
                            fullWidth
                            items={startOnOptions}
                            onChange={this.handleFieldChange}
                            propertyName="startOn"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <SaveBackCancelButtons
                            saveDisabled={
                                !this.editing() ||
                                (!sernosConfig.name || sernosConfig.name.length === 0)
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
SernosConfig.defaultProps = {
    sernosConfig: {},
    addSernosConfig: null,
    updateSernosConfig: null,
    loading: null,
    errorMessage: '',
    sernosConfigId: null,
    classes: {}
};

SernosConfig.propTypes = {
    classes: PropTypes.shape({}),
    sernosConfig: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    sernosConfigId: PropTypes.string,
    updateSernosConfig: PropTypes.func,
    addSernosConfig: PropTypes.func,
    loading: PropTypes.bool
};

export default SernosConfig;
