import React, { Component } from 'react';
import { Loading } from '@linn-it/linn-form-components-library';
import { Grid } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import {ReportTable } from '@linn-it/linn-form-components-library';
import { BackButton } from '@linn-it/linn-form-components-library';
import { ErrorCard } from '@linn-it/linn-form-components-library';

const styles = theme => ({
    root: {
      paddingLeft: "1%",
      paddingRight: "1%",
    },
    message: {
        paddingTop: "30px"
    }
});

class StockTriggerLevelsByPart extends Component {

    handleBackClick = () => {
        const { history } = this.props;
        let locationId = this.props.match.params.locationId;
        history.push('/products/reports/stock-trigger-levels/' + locationId);
    }

    render() {
        const { reportData, loading,  classes} = this.props;
        
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
                            showRowTitles={false}
                            title={reportData ? reportData.title.displayString : null}
                            showTitle={true} 
                        /> : <ErrorCard errorMessage="No Stock Found" className={classes.message}  /> }
                    </Grid>
                    <Grid item xs={12}>   
                        <BackButton backClick ={this.handleBackClick} />
                    </Grid>
                </Grid>
            </div>
        );
    }
}

export default withStyles(styles)(StockTriggerLevelsByPart);