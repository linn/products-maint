import React, { Component } from 'react';
import { withStyles } from '@material-ui/core/styles';
import moment from 'moment';
import { Grid } from '@material-ui/core';
import {
    InputField,
    Title,
    ErrorCard,
    Loading,
    SaveBackCancelButtons
} from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

const styles = () => ({});

class ProductRange extends Component {
    constructor(props) {
        super(props);
        this.state = {
            productRange: props.productRange
        };
        this.handleFieldChange = this.handleFieldChange.bind(this);
    }

    static getDerivedStateFromProps(props, state) {
        if (!state.productRange && props.productRange) {
            return { productRange: props.productRange };
        }

        if (
            state.productRange &&
            props.productRange &&
            state.productRange.id !== props.productRange.id
        ) {
            return { productRange: props.productRange };
        }

        return null;
    }

    handleSaveClick = () => {
        const { id, updateProductRange, addProductRange } = this.props;
        const { productRange } = this.state;

        if (this.editing()) {
            updateProductRange(id, productRange);
        } else if (this.creating()) {
            addProductRange(productRange);
        }
    };

    handleResetClick = () => {
        const { productRange, setEditStatus, history } = this.props;

        this.setState({ productRange });
        if (this.creating()) {
            history.push('/products/maint/product-ranges');
        }

        setEditStatus('view');
    };

    handleBackClick = () => {
        const { history } = this.props;
        history.push('/products/maint/product-ranges');
    };

    creating() {
        const { editStatus } = this.props;
        return editStatus === 'create';
    }

    editing() {
        const { editStatus } = this.props;
        return editStatus === 'edit';
    }

    viewing() {
        const { editStatus } = this.props;
        return editStatus === 'view';
    }

    handleFieldChange(propertyName, newValue) {
        const { productRange } = this.state;
        const { setEditStatus } = this.props;

        if (this.viewing()) {
            setEditStatus('edit');
        }

        this.setState({ productRange: { ...productRange, [propertyName]: newValue } });
    }

    render() {
        const { loading, errorMessage } = this.props;
        const { productRange } = this.state;

        if (loading || !productRange) {
            return <Loading />;
        }

        return (
            <Page>
                <Grid container spacing={24}>
                    <Grid item xs={12}>
                        <Title id="qa-product-range-title" text="Product Range Details" />
                    </Grid>
                    {errorMessage && (
                        <Grid item xs={12}>
                            <ErrorCard errorMessage={errorMessage} />
                        </Grid>
                    )}
                    <Grid item xs={3}>
                        <InputField
                            label="Id"
                            disabled
                            fullWidth
                            propertyName="id"
                            value={productRange.id}
                        />
                    </Grid>
                    <Grid item xs={9} />
                    <Grid item xs={3}>
                        <InputField
                            propertyName="rangeName"
                            label="Name"
                            maxLength={30}
                            fullWidth
                            value={productRange.rangeName}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <InputField
                            label="Description"
                            fullWidth
                            maxLength={150}
                            propertyName="rangeDescription"
                            value={productRange.rangeDescription}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={1} />
                    <Grid item xs={3}>
                        <InputField
                            label="Date Invalid"
                            type="date"
                            fullWidth
                            propertyName="dateInvalid"
                            value={moment(productRange.dateInvalid).format('YYYY-MM-DD')}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <SaveBackCancelButtons
                            saveDisabled={this.viewing()}
                            saveClick={this.handleSaveClick}
                            cancelClick={this.handleResetClick}
                            backClick={this.handleBackClick}
                        />
                    </Grid>
                </Grid>
            </Page>
        );
    }
}

ProductRange.propTypes = {
    id: PropTypes.number,
    productRange: PropTypes.shape({
        id: PropTypes.number,
        rangeName: PropTypes.string,
        rangeDescription: PropTypes.string,
        dateInvalid: PropTypes.string
    }),
    classes: PropTypes.shape({}),
    loading: PropTypes.bool,
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    errorMessage: PropTypes.string,
    updateProductRange: PropTypes.func,
    addProductRange: PropTypes.func,
    setEditStatus: PropTypes.func.isRequired,
    editStatus: PropTypes.string.isRequired
};

ProductRange.defaultProps = {
    id: null,
    loading: false,
    classes: {},
    errorMessage: '',
    productRange: null,
    addProductRange: null,
    updateProductRange: null
};

export default withStyles(styles)(ProductRange);
