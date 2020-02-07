import React, { Component } from 'react';
import {
    Loading,
    ErrorCard,
    Title,
    BackButton,
    ReportTable
} from '@linn-it/linn-form-components-library';
import { Grid, Paper } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import PropTypes from 'prop-types';

const styles = () => ({
    root: {
        margin: 40,
        padding: 40,
        paddingTop: '30px',
        paddingBottom: '30px'
    },
    message: {
        paddingTop: '100px',
        paddingBottom: '100px'
    }
});

class StockTriggerLevelsByPart extends Component {
    handleBackClick = () => {
        const { history, match } = this.props;
        const { locationId } = match.params;

        history.push(`/products/reports/parts-at-location/${locationId}`);
    };

    render() {
        const { reportData, classes } = this.props;

        return (
            <Paper className={classes.root}>
                <Grid container spacing={3} justify="center">
                    <Grid item xs={12}>
                        <Title text={reportData ? reportData.title.displayString : null} />
                    </Grid>
                    <Grid item xs={12}>
                        <BackButton backClick={this.handleBackClick} />
                    </Grid>
                    <Grid item xs={12}>
                        {!reportData ? (
                            <Loading />
                        ) : reportData.results.length > 0 ? (
                            <ReportTable
                                reportData={reportData}
                                showTotals={false}
                                showRowTitles={false}
                                title={reportData.title.displayString}
                                showTitle={false}
                            />
                        ) : (
                            <Paper className={classes.message}>
                                <ErrorCard
                                    errorMessage="No Stock Found"
                                    className={classes.message}
                                />
                            </Paper>
                        )}
                    </Grid>
                </Grid>
            </Paper>
        );
    }
}

StockTriggerLevelsByPart.propTypes = {
    reportData: PropTypes.shape({}),
    classes: PropTypes.shape({}),
    match: PropTypes.shape({}).isRequired,
    history: PropTypes.shape({ push: PropTypes.func }).isRequired
};

StockTriggerLevelsByPart.defaultProps = {
    reportData: null,
    classes: {}
};

export default withStyles(styles)(StockTriggerLevelsByPart);
