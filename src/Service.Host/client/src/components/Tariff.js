import React, { Component, Fragment } from 'react';
import { withStyles } from '@material-ui/core/styles';
import { Grid, Paper } from '@material-ui/core';
import {
    InputField,
    Title,
    ErrorCard,
    Loading,
    BackButton
} from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';

const styles = () => ({
    root: {
        margin: '40px',
        padding: '40px'
    }
});

class Tariff extends Component {
    constructor(props) {
        super(props);
        this.state = {
            tariff: null
        };
    }

    static getDerivedStateFromProps(props, state) {
        if (!state.tariff && props.tariff) {
            return { tariff: props.tariff };
        }
        return null;
    }

    handleBackClick = () => {
        const { history } = this.props;
        history.push('/products/maint/tariffs');
    };

    render() {
        const { loading, errorMessage, classes } = this.props;
        const { tariff } = this.state;

        return (
            <Paper className={classes.root}>
                <Grid container spacing={24}>
                    <Grid item xs={12}>
                        <Title text="Tariff Details" />
                    </Grid>
                    {errorMessage && (
                        <Grid item xs={12}>
                            <ErrorCard errorMessage={errorMessage} />
                        </Grid>
                    )}
                    {loading || !tariff ? (
                        <Grid item xs={12}>
                            <Loading />
                        </Grid>
                    ) : (
                        <Fragment>
                            <Grid item xs={4}>
                                <InputField
                                    label="Tariff Code"
                                    disabled
                                    fullWidth
                                    propertyName="tariffCode"
                                    value={tariff.tariffCode}
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <InputField
                                    label="Description"
                                    disabled
                                    rows={10}
                                    fullWidth
                                    propertyName="description"
                                    value={tariff.description}
                                />
                            </Grid>
                            <Grid item xs={4}>
                                <InputField
                                    label="US Tariff Code"
                                    disabled
                                    fullWidth
                                    propertyName="usTariffCode"
                                    value={tariff.usTariffCode}
                                />
                            </Grid>
                            <Grid item xs={4}>
                                <InputField
                                    label="Date Invalid"
                                    type="date"
                                    disabled
                                    fullWidth
                                    propertyName="dateInvalid"
                                    value={tariff.dateInvalid}
                                />
                            </Grid>
                            <Grid item xs={4}>
                                <InputField
                                    label="duty"
                                    adornment="%"
                                    disabled
                                    fullWidth
                                    propertyName="duty"
                                    value={tariff.duty}
                                />
                            </Grid>
                            <BackButton backClick={this.handleBackClick} />
                        </Fragment>
                    )}
                </Grid>
            </Paper>
        );
    }
}

Tariff.propTypes = {
    tariff: PropTypes.shape({
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
    errorMessage: PropTypes.string
};

Tariff.defaultProps = {
    loading: false,
    classes: {},
    errorMessage: '',
    tariff: null
};

export default withStyles(styles)(Tariff);
