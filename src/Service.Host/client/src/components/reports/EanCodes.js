import React, { Component } from 'react';
import { Loading } from '@linn-it/linn-form-components-library';
import Grid from '@material-ui/core/Grid';
import { ReportTable, ExportButton } from '@linn-it/linn-form-components-library';
import { withStyles } from '@material-ui/core/styles';

const styles = theme => ({
    root: {
      paddingLeft: "20%",
      paddingRight: "20%",
    },
});

class EanCodes extends Component {
    render() {
        const { reportData, loading, options, config, classes } = this.props;
        const optionsTitle = options.cartonisedOnly && options.cartonisedOnly !== 'false' ? '(Cartonised products only)' : '';
        const href =
            `${config.appRoot}/products/reports/sales-article-ean-codes/export?includePhasedOut=${options.includePhasedOut}&cartonisedOnly=${options.cartonisedOnly}`;

        return (
            <div className={classes.root}>
            <Grid container spacing={24} justify="center">
                    <Grid container xs={12}>
                    <Grid item xs={6}>
                            <h3>Sales Article Ean Codes {optionsTitle}</h3>
                        </Grid>
                        <Grid item xs={6}>
                            <ExportButton href={href} />
                        </Grid> 
                    </Grid>
                    <Grid item xs={12}>
                        {loading ? <Loading /> : ''}
                        <ReportTable reportData={reportData} showTotals={false} placeholderRows={10} placeholderColumns={3} showTitle={false} />
                    </Grid>
                </Grid>
            </div>
        );
    }
}

export default withStyles(styles)(EanCodes);