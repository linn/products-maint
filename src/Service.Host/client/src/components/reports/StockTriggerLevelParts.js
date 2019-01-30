import React, { Component } from 'react';
import { Loading } from '@linn-it/linn-form-components-library';
import { Grid, Paper } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';

import { ReportTable, Title, ErrorCard } from '@linn-it/linn-form-components-library';

const styles = theme => ({
    root: {
        margin: 40,
        padding: 40,

        paddingTop: "30px",
        paddingBottom: "30px"
    },
    message: {
        paddingTop: "100px",
        paddingBottom: "100px"
    }
});

class StockTriggerLevelParts extends Component {
    render() {
        const { reportData, loading, classes } = this.props;
        return (
            <Paper className={classes.root}>
                <Grid container spacing={24} justify="center">
                    <Grid item xs={12}>
                        <Title text={reportData ? reportData.title.displayString : null} />
                    </Grid>
                    <Grid item xs={12}>
                        {!reportData ? <Loading /> :
                            reportData.results.length > 0 ?
                                <ReportTable
                                    reportData={reportData}
                                    showTotals={false}
                                    showRowTitles={true}
                                    title={reportData ? reportData.title.displayString : null}
                                    showTitle={false}
                                /> : <Paper className={classes.message}>
                                    <ErrorCard errorMessage="No Stock Found" />
                                </Paper>}
                    </Grid>
                </Grid>
            </Paper>
        );
    }
}

export default withStyles(styles)(StockTriggerLevelParts);