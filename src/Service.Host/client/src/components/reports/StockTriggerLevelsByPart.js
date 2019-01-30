import React, { Component } from 'react';
import { Loading } from '@linn-it/linn-form-components-library';
import { Grid, Paper } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import { ReportTable } from '@linn-it/linn-form-components-library';
import { BackButton } from '@linn-it/linn-form-components-library';
import { ErrorCard, Title } from '@linn-it/linn-form-components-library';

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

class StockTriggerLevelsByPart extends Component {

    handleBackClick = () => {
        const { history } = this.props;
        let locationId = this.props.match.params.locationId;

        history.push('/products/reports/parts-at-location/' + locationId);
    }

    render() {
        const { reportData, loading, classes } = this.props;

        return (
            <Paper className={classes.root}>
                <Grid container spacing={24} justify="center">
                    <Grid item xs={12}>
                        <Title text={reportData ? reportData.title.displayString : null} />
                    </Grid>
                    <Grid item xs={12}>
                        <BackButton backClick={this.handleBackClick} />
                    </Grid>
                    <Grid item xs={12}>
                        {!reportData ? <Loading /> :
                            reportData.results.length > 0 ?
                                <ReportTable
                                    reportData={reportData}
                                    showTotals={false}
                                    showRowTitles={false}
                                    title={reportData ? reportData.title.displayString : null}
                                    showTitle={false}
                                /> : <Paper className={classes.message}>
                                    <ErrorCard errorMessage="No Stock Found" className={classes.message} />
                                </Paper>}
                    </Grid>

                </Grid>
            </Paper>
        );
    }
}

export default withStyles(styles)(StockTriggerLevelsByPart);