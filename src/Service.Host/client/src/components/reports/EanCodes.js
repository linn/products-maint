import React from 'react';
import { Grid, Typography } from '@material-ui/core';
import { ReportTable, ExportButton, Loading } from '@linn-it/linn-form-components-library';
import { withStyles } from '@material-ui/core/styles';
import PropTypes from 'prop-types';

const styles = () => ({
    root: {
        paddingLeft: '20%',
        paddingRight: '20%',
        marginTop: 40
    }
});

const EanCodes = ({ reportData, loading, options, config, classes }) => {
    const optionsTitle =
        options.cartonisedOnly && options.cartonisedOnly !== 'false'
            ? '(Cartonised products only)'
            : '';
    const href = `${config.appRoot}/products/reports/sales-article-ean-codes/export?includePhasedOut=${options.includePhasedOut}&cartonisedOnly=${options.cartonisedOnly}`;

    return (
        <div className={classes.root}>
            <Grid container spacing={24} justify="center">
                <Grid item xs={12}>
                    <Grid item xs={6}>
                        <Typography variant="h4" gutterBottom>
                            Sales Article Ean Codes {optionsTitle}
                        </Typography>
                    </Grid>
                    <Grid item xs={6}>
                        <ExportButton href={href} />
                    </Grid>
                </Grid>
                <Grid item xs={12}>
                    {loading ? <Loading /> : ''}
                    <ReportTable
                        reportData={reportData}
                        showTotals={false}
                        placeholderRows={10}
                        placeholderColumns={3}
                        showTitle={false}
                    />
                </Grid>
            </Grid>
        </div>
    );
};

EanCodes.propTypes = {
    reportData: PropTypes.shape({}),
    classes: PropTypes.shape({}),
    options: PropTypes.shape({}),
    config: PropTypes.shape({}),
    loading: PropTypes.bool
};

EanCodes.defaultProps = {
    reportData: null,
    classes: {},
    options: {},
    config: {},
    loading: false
};

export default withStyles(styles)(EanCodes);
