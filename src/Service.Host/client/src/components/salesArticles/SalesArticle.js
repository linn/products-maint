import React, { Component } from 'react';
import { withStyles } from '@material-ui/core/styles';
import moment from 'moment';
import { Grid, Paper } from '@material-ui/core';
import { InputField, Title, ErrorCard, Loading } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import SaveBackCancelButtons from '../common/SaveBackCancelButtons';

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
            salesArticle: props.salesArticle,
            editStatus: props.editStatus || 'view'
        };
        this.handleFieldChange = this.handleFieldChange.bind(this);
    }

    componentWillReceiveProps(nextProps) {
        this.setState({
            editStatus: nextProps.editStatus,
            salesArticle: this.setArticleFromProps(nextProps.salesArticle)
        });
    }

    setArticleFromProps = salesArticle => {
        let percentageOfRootProductSales = '';
        if (salesArticle) {
            percentageOfRootProductSales =
                salesArticle.percentageOfRootProductSales ||
                salesArticle.percentageOfRootProductSales === 0
                    ? salesArticle.percentageOfRootProductSales
                    : '';
        }

        return {
            ...salesArticle,
            percentageOfRootProductSales
        };
    };

    handleSaveClick = () => {
        const { id, updateSalesArticle } = this.props;
        const { salesArticle } = this.state;

        updateSalesArticle(id, salesArticle);
    };

    handleResetClick = () => {
        const { salesArticle } = this.props;

        this.setState({ salesArticle: this.setArticleFromProps(salesArticle) });
        this.setState({ editStatus: 'view' });
    };

    handleBackClick = () => {
        const { history } = this.props;
        history.push('/products/maint/sales-articles');
    };

    editing() {
        const { editStatus } = this.state;

        return editStatus === 'edit';
    }

    viewing() {
        const { editStatus } = this.state;
        return editStatus === 'view';
    }

    handleFieldChange(propertyName, newValue) {
        const { salesArticle } = this.state;
        this.setState({ editStatus: 'edit' });
        this.setState({ salesArticle: { ...salesArticle, [propertyName]: newValue } });
    }

    render() {
        const { loading, errorMessage, classes } = this.props;
        const { salesArticle } = this.state;

        if (loading || !salesArticle) {
            return <Loading />;
        }

        return (
            <Paper className={classes.root}>
                <Grid container spacing={24}>
                    <Grid item xs={12}>
                        <Title text="Sales Article Details" />
                    </Grid>
                    {errorMessage && (
                        <Grid item xs={12}>
                            <ErrorCard errorMessage={errorMessage} />
                        </Grid>
                    )}
                    <Grid item xs={5}>
                        <InputField
                            label="Article Number"
                            disabled
                            propertyName="id"
                            value={salesArticle.articleNumber}
                        />
                    </Grid>
                    <Grid item xs={7}>
                        <InputField
                            propertyName="description"
                            label="Description"
                            fullWidth
                            disabled
                            value={salesArticle.description}
                        />
                    </Grid>
                    <Grid item xs={5}>
                        <InputField
                            label="Forecast From"
                            type="date"
                            propertyName="forecastFromDate"
                            value={moment(salesArticle.forecastFromDate).format('YYYY-MM-DD')}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={7}>
                        <InputField
                            label="Forecast To"
                            type="date"
                            propertyName="forecastToDate"
                            value={moment(salesArticle.forecastToDate).format('YYYY-MM-DD')}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={5}>
                        <InputField
                            label="Forecast Type"
                            propertyName="forecastType"
                            value={salesArticle.forecastType}
                            onChange={this.handleFieldChange}
                        />
                    </Grid>
                    <Grid item xs={7}>
                        <InputField
                            label="% of Root Product Sales"
                            type="number"
                            propertyName="percentageOfRootProductSales"
                            value={salesArticle.percentageOfRootProductSales}
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
            </Paper>
        );
    }
}

SalesArticle.propTypes = {
    id: PropTypes.string.isRequired,
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
    editStatus: PropTypes.string
};

SalesArticle.defaultProps = {
    loading: false,
    classes: {},
    errorMessage: '',
    editStatus: 'view',
    salesArticle: null
};

export default withStyles(styles)(SalesArticle);
