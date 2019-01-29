import React, { Component } from 'react';
import { Loading } from '@linn-it/linn-form-components-library';
import { Grid } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import {ReportTable } from '@linn-it/linn-form-components-library';

const styles = theme => ({
    root: {
      paddingLeft: "1%",
      paddingRight: "1%",
      
    },
});

class StockTriggerLevelParts extends Component {
    render() {
        const { reportData, loading,  classes } = this.props;
        return (
            <div className={classes.root}>
                <Grid container spacing={24} justify="center">
                    <Grid item xs={12}>   
                    </Grid>
                    <Grid item xs={12}>
                    { !reportData ? <Loading /> :
                        reportData.results.length > 0 ?
                        <ReportTable 
                            reportData={reportData} 
                            showTotals={false} 
                            showRowTitles={true}
                            title={reportData ? reportData.title.displayString : null}
                            showTitle={true} 
                    /> : <ErrorCard errorMessage="No Stock Found" className={classes.message}  /> }
                    </Grid>
                </Grid>
            </div>
        );
    }
}

export default withStyles(styles)(StockTriggerLevelParts);