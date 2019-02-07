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

class CartonType extends Component {
    constructor(props) {
        super(props);
        this.handleFieldChange = this.handleFieldChange.bind(this);
        this.state = {
            editStatus: 'view',
            cartonType: null
        };
    }

    static getDerivedStateFromProps(props, state) {
        if (!state.cartonType && props.cartonType) {
            return { cartonType: props.cartonType };
        }
        return null;
    }

    handleSaveClick = () => {
        const { cartonTypeId, updateCartonType } = this.props;
        updateCartonType(cartonTypeId, { ...this.state }.cartonType);
        this.setState({ editStatus: 'view' });
    };

    handleCancelClick = () => {
        const { cartonType } = this.props;
        this.setState({ cartonType });
        this.setState({ editStatus: 'view' });
    };

    handleAddClick = () => {
        const { addCartonType } = this.props;
        const { cartonType } = this.state;
        addCartonType(cartonType);
        this.setState({ editStatus: 'view' });
    };

    handleBackClick = () => {
        this.setState({ editStatus: 'view' });
        const { history } = this.props;
        history.push('/products/reports/carton-details/report');
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
            cartonType: {
                ...prevState.cartonType,
                [propertyName]: val
            },
            editStatus: 'edit'
        }));
    }

    render() {
        const { loading, errorMessage } = this.props;
        const { cartonType } = this.state;
        if (loading || !cartonType) {
            return <Loading />;
        }

        return (
            <Page>
                <Grid container spacing={24}>
                    <Grid item xs={12}>
                        {this.creating() ? (
                            <Title text="Create Carton Type" />
                        ) : (
                            <Title text="Carton Type Details" />
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
                            value={cartonType.name}
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
                    <Grid item xs={8}>
                        <InputField
                            value={cartonType.description}
                            label="Description"
                            fullWidth
                            onChange={this.handleFieldChange}
                            propertyName="description"
                        />
                    </Grid>
                    <Grid item xs={4}>
                        <InputField
                            fullWidth
                            type="number"
                            value={cartonType.width}
                            label="Width"
                            onChange={this.handleFieldChange}
                            propertyName="width"
                        />
                    </Grid>
                    <Grid item xs={4}>
                        <InputField
                            fullWidth
                            type="number"
                            value={cartonType.height}
                            label="Height"
                            onChange={this.handleFieldChange}
                            propertyName="height"
                        />
                    </Grid>
                    <Grid item xs={4}>
                        <InputField
                            fullWidth
                            type="number"
                            value={cartonType.depth}
                            label="Depth"
                            onChange={this.handleFieldChange}
                            propertyName="depth"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <SaveBackCancelButtons
                            saveDisabled={
                                !this.editing() ||
                                (!cartonType.name || cartonType.name.length === 0)
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

CartonType.defaultProps = {
    cartonType: {},
    addCartonType: null,
    updateCartonType: null,
    loading: null,
    errorMessage: '',
    cartonTypeId: null
};

CartonType.propTypes = {
    cartonType: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    cartonTypeId: PropTypes.string,
    updateCartonType: PropTypes.func,
    addCartonType: PropTypes.func,
    loading: PropTypes.bool
};

export default CartonType;
