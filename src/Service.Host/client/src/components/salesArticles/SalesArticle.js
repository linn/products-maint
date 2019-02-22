import React, { Component } from 'react';
import { withStyles } from '@material-ui/core/styles';
import moment from 'moment';
import { Grid } from '@material-ui/core';
import {
    InputField,
    Title,
    ErrorCard,
    Loading,
    SaveBackCancelButtons,
    Dropdown
} from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import { getSelfHref, getHref } from '../../helpers/utilities';
import Page from '../../containers/Page';

const styles = () => ({
    root: {
        margin: '40px',
        padding: '40px'
    }
});

class SalesArticle extends Component {
    constructor(props) {
        super(props);
        this.state = {
            salesArticle: props.salesArticle
        };
        this.handleFieldChange = this.handleFieldChange.bind(this);
        this.handleLinkRelChange = this.handleLinkRelChange.bind(this);
    }

    static getDerivedStateFromProps(props, state) {
        if (!state.salesArticle && props.salesArticle) {
            return { salesArticle: props.salesArticle };
        }

        return null;
    }

    handleSaveClick = () => {
        const { id, updateSalesArticle } = this.props;
        const { salesArticle } = this.state;

        updateSalesArticle(id, salesArticle);
    };

    handleResetClick = () => {
        const { salesArticle, setEditStatus } = this.props;

        this.setState({ salesArticle });
        setEditStatus('view');
    };

    handleBackClick = () => {
        const { history } = this.props;
        history.push('/products/maint/sales-articles');
    };

    editing() {
        const { editStatus } = this.props;

        return editStatus === 'edit';
    }

    viewing() {
        const { editStatus } = this.props;
        return editStatus === 'view';
    }

    handleFieldChange(propertyName, newValue) {
        const { salesArticle } = this.state;
        const { setEditStatus } = this.props;

        setEditStatus('edit');
        this.setState({ salesArticle: { ...salesArticle, [propertyName]: newValue } });
    }

    handleLinkRelChange(rel, newValue) {
        const { salesArticle } = this.state;
        const { setEditStatus } = this.props;

        setEditStatus('edit');
        const links = salesArticle.links.filter(l => l.rel !== 'sa-core-type');

        if (newValue) {
            links.push({ rel, href: newValue });
        }

        this.setState({ salesArticle: { ...salesArticle, links } });
    }

    render() {
        const { loading, errorMessage, saCoreTypes } = this.props;
        const { salesArticle } = this.state;
        const salesArticleCoreTypeHref = getHref(salesArticle, 'sa-core-type')
            ? getHref(salesArticle, 'sa-core-type')
            : '';

        let saCoreTypeItems;
        if (saCoreTypes.length > 0) {
            saCoreTypeItems = saCoreTypes
                .filter(sa => !sa.dateInvalid)
                .map(sa => ({
                    id: getSelfHref(sa),
                    displayText: sa.description
                }));
            saCoreTypeItems.push({ id: '', displayText: '' });
        } else {
            saCoreTypeItems = [
                { id: salesArticleCoreTypeHref, displayText: salesArticleCoreTypeHref || 'Waiting' }
            ];
        }

        const forecastTypes = [
            { id: 'Y', displayText: 'Yes' },
            { id: 'N', displayText: 'No' },
            { id: '', displayText: '' }
        ];

        if (loading || !salesArticle) {
            return <Loading />;
        }

        return (
            <Page>
                <Grid container spacing={24}>
                    <Grid item xs={12}>
                        <Title text="Sales Article Details" />
                    </Grid>
                    {errorMessage && (
                        <Grid item xs={12}>
                            <ErrorCard errorMessage={errorMessage} />
                        </Grid>
                    )}
                    <Grid item xs={3}>
                        <InputField
                            label="Article Number"
                            disabled
                            fullWidth
                            propertyName="id"
                            value={salesArticle.articleNumber}
                        />
                    </Grid>
                    <Grid item xs={1} />
                    <Grid item xs={7}>
                        <InputField
                            propertyName="description"
                            label="Description"
                            fullWidth
                            disabled
                            value={salesArticle.description}
                        />
                    </Grid>
                    <Grid item xs={3}>
                        <InputField
                            label="Forecast From"
                            type="date"
                            fullWidth
                            propertyName="forecastFromDate"
                            value={moment(salesArticle.forecastFromDate).format('YYYY-MM-DD')}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={1} />
                    <Grid item xs={3}>
                        <InputField
                            label="Forecast To"
                            type="date"
                            fullWidth
                            propertyName="forecastToDate"
                            value={moment(salesArticle.forecastToDate).format('YYYY-MM-DD')}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={4} />
                    <Grid item xs={3}>
                        <Dropdown
                            label="Forecast Type"
                            propertyName="forecastType"
                            items={forecastTypes}
                            fullWidth
                            value={salesArticle.forecastType}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={1} />
                    <Grid item xs={3}>
                        <InputField
                            label="% of Root Product Sales"
                            type="number"
                            fullWidth
                            propertyName="percentageOfRootProductSales"
                            value={salesArticle.percentageOfRootProductSales}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={4} />
                    <Grid item xs={3}>
                        <Dropdown
                            label="Core Type"
                            propertyName="sa-core-type"
                            items={saCoreTypeItems}
                            fullWidth
                            value={salesArticleCoreTypeHref}
                            onChange={this.handleLinkRelChange}
                        />
                    </Grid>
                    <Grid item xs={1} />
                    <Grid item xs={3} />
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

SalesArticle.propTypes = {
    id: PropTypes.string.isRequired,
    saCoreTypes: PropTypes.arrayOf(PropTypes.shape({})),
    salesArticle: PropTypes.shape({
        id: PropTypes.string,
        description: PropTypes.string,
        forecastFromDate: PropTypes.string,
        forecastToDate: PropTypes.string,
        forecastType: PropTypes.string,
        percentageOfRootProductSales: PropTypes.number
    }),
    classes: PropTypes.shape({}),
    loading: PropTypes.bool,
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    errorMessage: PropTypes.string,
    updateSalesArticle: PropTypes.func.isRequired,
    setEditStatus: PropTypes.func.isRequired,
    editStatus: PropTypes.string
};

SalesArticle.defaultProps = {
    loading: false,
    classes: {},
    errorMessage: '',
    editStatus: 'view',
    salesArticle: null,
    saCoreTypes: []
};

export default withStyles(styles)(SalesArticle);
