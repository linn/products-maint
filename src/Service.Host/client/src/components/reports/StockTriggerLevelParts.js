import React, { Component } from 'react';
import { Loading } from '@linn-it/linn-form-components-library';
import Grid from '@material-ui/core/Grid';
import { withStyles } from '@material-ui/core/styles';
import {ReportTable } from '@linn-it/linn-form-components-library';

const styles = theme => ({
    root: {
      paddingLeft: "20%",
      paddingRight: "20%",
    },
});

class StockTriggerLevelParts extends Component {
    render() {
        const { reportData, loading,  classes } = this.props;
        return (
            <div className={classes.root}>
                <Grid container spacing={24} justify="center">
                    <Grid item xs={12}>   
                        <h3>Stock Trigger Levels</h3>    
                    </Grid>
                    <Grid item xs={12}>
                        {loading ? <Loading /> : ''}
                        <ReportTable 
                            reportData={reportData} 
                            showTotals={false} 
                            showRowTitles={true}
                            title={reportData ? reportData.title.displayString : null}
                            showTitle={true} 
                        />
                    </Grid>
                </Grid>
            </div>
        );
    }
}

export default withStyles(styles)(StockTriggerLevelParts);