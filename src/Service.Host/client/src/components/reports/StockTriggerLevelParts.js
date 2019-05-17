import React from 'react';
import { Grid, Paper } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import { ReportTable, Title, ErrorCard, Loading } from '@linn-it/linn-form-components-library';
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

function StockTriggerLevelParts({ reportData, classes }) {
    return (
        <Paper className={classes.root}>
            <Grid container spacing={24} justify="center">
                <Grid item xs={12}>
                    <Title text={reportData ? reportData.title.displayString : null} />
                </Grid>
                <Grid item xs={12}>
                    {!reportData ? (
                        <Loading />
                    ) : reportData.results.length > 0 ? (
                        <ReportTable
                            reportData={reportData}
                            showTotals={false}
                            showRowTitles
                            title={reportData.title ? reportData.title.displayString : null}
                            showTitle={false}
                        />
                    ) : (
                        <Paper className={classes.message}>
                            <ErrorCard errorMessage="No Stock Found" />
                        </Paper>
                    )}
                </Grid>
            </Grid>
        </Paper>
    );
}

StockTriggerLevelParts.propTypes = {
    reportData: PropTypes.shape({}),
    classes: PropTypes.shape({})
};

StockTriggerLevelParts.defaultProps = {
    reportData: null,
    classes: {}
};

export default withStyles(styles)(StockTriggerLevelParts);
