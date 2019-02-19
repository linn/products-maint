import React, { Component } from 'react';
import { Button, Grid, Typography } from '@material-ui/core';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

class SalesArticleCoreTypesOptions extends Component {
    constructor(props) {
        super(props);
    }

    handleClick() {
        const { history } = this.props;
        history.push({ pathname: `/products/reports/sales-article-core-types/report` });
    }

    render() {
        return (
            <Page>
                <Grid style={{ marginTop: 40 }} container spacing={24}>
                    <Grid item xs={12}>
                        <Typography variant="h4" gutterBottom>
                            Sales Articles Core Types Report Options
                        </Typography>
                    </Grid>
                    <Button variant="outlined" onClick={() => this.handleClick()}>
                        Run Report
                    </Button>
                </Grid>
            </Page>
        );
    }
}

SalesArticleCoreTypesOptions.propTypes = {
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    prevOptions: PropTypes.shape({
        includePhasedOut: PropTypes.bool,
        cartonisedOnly: PropTypes.bool
    })
};

SalesArticleCoreTypesOptions.defaultProps = {
    prevOptions: {}
};

export default SalesArticleCoreTypesOptions;
