import React, { Component, Fragment } from 'react';
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

class VatCode extends Component {
    constructor(props) {
        super(props);
        this.handleFieldChange = this.handleFieldChange.bind(this);
        this.state = {
            vatCode: null
        };
    }

    static getDerivedStateFromProps(props, state) {
        if (!state.vatCode && props.vatCode) {
            return { vatCode: props.vatCode };
        }
        return null;
    }

    handleSaveClick = () => {
        const { vatCodeId, updateVatCode, setEditStatus } = this.props;
        const { vatCode } = this.state;

        updateVatCode(vatCodeId, vatCode);
        setEditStatus('view');
        // this.setState({ editStatus: 'view' });
    };

    handleCancelClick = () => {
        const { vatCode, setEditStatus } = this.props;
        this.setState({ vatCode });
        setEditStatus('view');
        // this.setState({ editStatus: 'view' });
    };

    handleAddClick = () => {
        const { addVatCode, setEditStatus } = this.props;
        const { vatCode } = this.state;
        addVatCode(vatCode);
        setEditStatus('view');
        // this.setState({ editStatus: 'view' });
    };

    handleBackClick = () => {
        // this.setState({ editStatus: 'view' });
        const { history } = this.props;
        history.push('/products/maint/vat-codes');
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
        const { vatCode } = this.state;
        const { setEditStatus } = this.props;

        setEditStatus('edit');
        this.setState({ vatCode: { ...vatCode, [propertyName]: newValue } });
    }

    render() {
        const { loading, errorMessage } = this.props;
        const { vatCode } = this.state;

        return (
            <Page>
                <Grid container spacing={24}>
                    <Grid item xs={12}>
                        {this.creating() ? (
                            <Title text="Create Vat Code" />
                        ) : (
                            <Title text="Vat Code Details" />
                        )}
                    </Grid>
                    {errorMessage && (
                        <Grid item xs={12}>
                            <ErrorCard errorMessage={errorMessage} />
                        </Grid>
                    )}
                    {loading || !vatCode ? (
                        <Grid item xs={12}>
                            <Loading />
                        </Grid>
                    ) : (
                        // TODO are these grid item xs needed or should all be fragments?
                        <Fragment>
                            <Grid item xs={8}>
                                <InputField
                                    fullWidth
                                    disabled={!this.creating()}
                                    value={vatCode.code}
                                    label="VAT Code"
                                    helperText={
                                        !this.creating()
                                            ? 'This field cannot be changed'
                                            : 'This field is required'
                                    }
                                    onChange={this.handleFieldChange}
                                    propertyName="code"
                                />
                            </Grid>
                            <Grid item xs={8}>
                                <InputField
                                    value={vatCode.description}
                                    label="Description"
                                    fullWidth
                                    onChange={this.handleFieldChange}
                                    propertyName="description"
                                />
                            </Grid>
                            <Grid item xs={8}>
                                <InputField
                                    value={vatCode.rate}
                                    label="Rate"
                                    fullWidth
                                    onChange={this.handleFieldChange}
                                    propertyName="rate"
                                    type="number"
                                />
                            </Grid>
                            <Grid item xs={8}>
                                <InputField
                                    value={vatCode.reason}
                                    label="Reason"
                                    fullWidth
                                    onChange={this.handleFieldChange}
                                    propertyName="reason"
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <SaveBackCancelButtons
                                    saveDisabled={
                                        !this.editing() ||
                                        (!vatCode.code || vatCode.code.length === 0)
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

VatCode.propTypes = {
    vatCode: PropTypes.shape({
        vatCode: PropTypes.string,
        description: PropTypes.string,
        rate: PropTypes.number,
        reason: PropTypes.string
    }),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    vatCodeId: PropTypes.string,
    updateVatCode: PropTypes.func,
    addVatCode: PropTypes.func,
    loading: PropTypes.bool,
    setEditStatus: PropTypes.func.isRequired
};

VatCode.defaultProps = {
    vatCode: {},
    addVatCode: null,
    updateVatCode: null,
    loading: null,
    errorMessage: '',
    vatCodeId: null
};

export default VatCode;
