import React, { Component } from 'react';
import { withStyles } from '@material-ui/core/styles';
import moment from 'moment';
import { Grid } from '@material-ui/core';
import {
    BackButton,
    SaveCancelButtons,
    FormField,
    Title
} from '@linn-it/linn-form-components-library';
import { Loading } from '../common/Loading';

const styles = () => ({
    root: {
        width: "70%",
        margin: 40
    },
    grid: {
        width: "100%",
        margin: "0 auto"
    }
});

class SalesArticle extends Component {
    constructor(props) {
        super(props);
        this.state = { salesArticle: this.props.salesArticle, editStatus: this.props.editStatus || "view" };
        this.handleFieldChange = this.handleFieldChange.bind(this);
    }

    componentWillReceiveProps(nextProps) {
        this.setState({ editStatus: nextProps.editStatus, salesArticle: nextProps.salesArticle });
    }

    // Status
    viewing() {
        return this.state.editStatus === 'view';
    }

    editing() {
        return this.state.editStatus === 'edit';
    }

    // Button event Handlers
    handleSaveClick = () => {
        const { id, updateSalesArticle } = this.props;
        updateSalesArticle(id, this.state.salesArticle);
    }

    handleResetClick = () => {
        this.setState({ salesArticle: this.props.salesArticle });
    }

    handleCancelClick = () => {
        const { history } = this.props;
        history.push('/products/maint/sales-articles');
    }

    // Fields Change Event Handler
    handleFieldChange(propertyName, newValue) {
        this.setState({ salesArticle: { ...this.state.salesArticle, [propertyName]: newValue } });
    }

    render() {
        const { salesArticle, loading, errorMessage, classes } = this.props;

        if (loading || !salesArticle) {
            return (
                <Loading />);
        }

        return (
            <div className={classes.root}>
                <Grid container spacing={24}>
                    <Grid item xs={12} >
                        <Title text="Sales Article Details" />
                    </Grid>
                    <Grid item xs={6} >
                        <FormField
                            config={{
                                label: "Article Number",
                                disabled: true
                            }}
                            propertyName="id"
                            value={this.state.salesArticle.articleNumber} />
                    </Grid>
                    <Grid item xs={6}>
                        <FormField
                            propertyName="description"
                            config={{
                                label: "Description",
                                disabled: true
                            }}
                            propertyName="description"
                            value={this.state.salesArticle.description}
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <FormField
                            config={{
                                label: "Forecast From",
                                type: "date"
                            }}
                            propertyName="forecastFromDate"
                            value={moment(this.state.salesArticle.forecastFromDate).format('YYYY-MM-DD')}
                            onChange={this.handleFieldChange} />
                    </Grid>
                    <Grid item xs={6}>
                        <FormField
                            config={{
                                label: "Forecast To",
                                type: "date"
                            }}
                            propertyName="forecastToDate"
                            value={moment(this.state.salesArticle.forecastToDate).format('YYYY-MM-DD')}
                            onChange={this.handleFieldChange} />
                    </Grid>
                    <Grid item xs={6}>
                        <FormField
                            config={{
                                label: "Forecast Type"
                            }}
                            propertyName="forecastType"
                            value={this.state.salesArticle.forecastType} 
                            onChange={this.handleFieldChange} />
                    </Grid>
                    <Grid item xs={6}>
                        <FormField
                            config={{
                                label: "% of Root Product Sales",
                                type: "number"
                            }}
                            propertyName="percentageOfRootProductSales"
                            value={this.state.salesArticle.percentageOfRootProductSales}
                            onChange={this.handleFieldChange} />
                    </Grid>
                    <Grid item xs={12}>
                        <BackButton
                            backClick={this.handleCancelClick} />
                        <SaveCancelButtons
                            disabled={JSON.stringify(this.state.salesArticle) === JSON.stringify(salesArticle)}
                            saveClick={this.handleSaveClick}
                            cancelClick={this.handleResetClick} />
                    </Grid>
                </Grid>
            </div>
        );
    }
}

export default withStyles(styles)(SalesArticle);
