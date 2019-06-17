import React from 'react';
import { Button, Grid, Typography } from '@material-ui/core';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

const SalesArticleCoreTypesOptions = ({ history }) => {
    const handleClick = () => {
        history.push({ pathname: `/products/reports/sales-article-core-types/report` });
    };

    return (
        <Page>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <Typography variant="h4" gutterBottom>
                        Sales Articles Core Types Report Options
                    </Typography>
                </Grid>
                <Button variant="outlined" onClick={() => handleClick()}>
                    Run Report
                </Button>
            </Grid>
        </Page>
    );
};

SalesArticleCoreTypesOptions.propTypes = {
    history: PropTypes.shape({ push: PropTypes.func }).isRequired
};

export default SalesArticleCoreTypesOptions;
