import React, { Component, Fragment } from 'react';
import PropTypes from 'prop-types';
import { Grid } from '@material-ui/core';
import {
    OnOffSwitch,
    SaveBackCancelButtons,
    InputField,
    Loading,
    Title,
    ErrorCard
} from '@linn-it/linn-form-components-library';
import Page from '../containers/Page';

class TypeOfSale extends Component {
    constructor(props) {
        super(props);
        this.handleFieldChange = this.handleFieldChange.bind(this);
        this.handleSwitchChange = this.handleSwitchChange.bind(this);
        this.state = {
            editStatus: 'view',
            typeOfSale: null
        };
    }

    static getDerivedStateFromProps(props, state) {
        if (!state.typeOfSale && props.typeOfSale) {
            return { typeOfSale: props.typeOfSale };
        }
        return null;
    }

    handleSaveClick = () => {
        const { typeOfSaleId, updateTypeOfSale } = this.props;
        updateTypeOfSale(typeOfSaleId, { ...this.state }.typeOfSale);
        this.setState({ editStatus: 'view' });
    };

    handleCancelClick = () => {
        const { typeOfSale } = this.props;
        this.setState({ typeOfSale });
        this.setState({ editStatus: 'view' });
    };

    handleAddClick = () => {
        const { addTypeOfSale } = this.props;
        const { typeOfSale } = this.state;
        addTypeOfSale(typeOfSale);
        this.setState({ editStatus: 'view' });
    };

    handleBackClick = () => {
        this.setState({ editStatus: 'view' });
        const { history } = this.props;
        history.push('/products/maint/types-of-sale');
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
            typeOfSale: {
                ...prevState.typeOfSale,
                [propertyName]: val
            },
            editStatus: 'edit'
        }));
    }

    handleSwitchChange(propertyName, val) {
        this.setState(prevState => ({
            typeOfSale: {
                ...prevState.typeOfSale,
                [propertyName]: val ? 'Y' : 'N'
            },
            editStatus: 'edit'
        }));
    }

    render() {
        const { loading, errorMessage } = this.props;
        const { typeOfSale } = this.state;
        return (
            <Page>
                <Grid container spacing={24}>
                    <Grid item xs={12}>
                        {this.creating() ? (
                            <Title text="Create Type of Sale" />
                        ) : (
                            <Title text="Type of Sale Details" />
                        )}
                    </Grid>
                    {errorMessage && (
                        <Grid item xs={12}>
                            <ErrorCard errorMessage={errorMessage} />
                        </Grid>
                    )}
                    {loading || !typeOfSale ? (
                        <Grid item xs={12}>
                            <Loading />
                        </Grid>
                    ) : (
                        <Fragment>
                            <Grid item xs={4}>
                                <InputField
                                    fullWidth
                                    disabled={!this.creating()}
                                    value={typeOfSale.name}
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
                                    value={typeOfSale.description}
                                    label="Description"
                                    fullWidth
                                    onChange={this.handleFieldChange}
                                    propertyName="description"
                                />
                            </Grid>
                            <Grid item xs={8}>
                                <InputField
                                    value={typeOfSale.department}
                                    label="Department"
                                    fullWidth
                                    onChange={this.handleFieldChange}
                                    propertyName="department"
                                />
                            </Grid>
                            <Grid item xs={8}>
                                <InputField
                                    value={typeOfSale.nominal}
                                    label="Nominal"
                                    fullWidth
                                    onChange={this.handleFieldChange}
                                    propertyName="nominal"
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <OnOffSwitch
                                    label="Real Sale"
                                    value={typeOfSale.realSale === 'Y'}
                                    onChange={this.handleSwitchChange}
                                    propertyName="realSale"
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <SaveBackCancelButtons
                                    saveDisabled={
                                        !this.editing() ||
                                        (!typeOfSale.name || typeOfSale.name.length === 0)
                                    }
                                    saveClick={
                                        this.creating() ? this.handleAddClick : this.handleSaveClick
                                    }
                                    cancelClick={this.handleCancelClick}
                                    backClick={this.handleBackClick}
                                />
                            </Grid>
                        </Fragment>
                    )}
                </Grid>
            </Page>
        );
    }
}

TypeOfSale.defaultProps = {
    typeOfSale: {},
    addTypeOfSale: null,
    updateTypeOfSale: null,
    loading: null,
    errorMessage: '',
    typeOfSaleId: null
};

TypeOfSale.propTypes = {
    typeOfSale: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    typeOfSaleId: PropTypes.string,
    updateTypeOfSale: PropTypes.func,
    addTypeOfSale: PropTypes.func,
    loading: PropTypes.bool
};

export default TypeOfSale;
