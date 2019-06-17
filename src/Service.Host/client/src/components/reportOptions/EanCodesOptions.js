import React, { Component } from 'react';
import { Button, Grid, Typography } from '@material-ui/core';
import { OnOffSwitch } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

class EanCodesOptions extends Component {
    constructor(props) {
        super(props);
        this.handleChange = this.handleChange.bind(this);
        this.state = {
            includePhasedOut: props.prevOptions ? props.prevOptions.includePhasedOut : false,
            cartonisedOnly: props.prevOptions ? props.prevOptions.cartonisedOnly : true
        };
    }

    handleChange(propertyName, value) {
        this.setState({ [propertyName]: value });
    }

    handleClick() {
        const { history } = this.props;
        const { cartonisedOnly, includePhasedOut } = this.state;

        history.push({
            pathname: `/products/reports/sales-article-ean-codes/report`,
            search: `?includePhasedOut=${includePhasedOut}&cartonisedOnly=${cartonisedOnly}`
        });
    }

    render() {
        const { includePhasedOut, cartonisedOnly } = this.state;

        return (
            <Page>
                <Grid style={{ marginTop: 40 }} container spacing={3} justify="center">
                    <Grid item xs={12}>
                        <Typography variant="h4" gutterBottom>
                            Ean Codes of Sales Articles Report Options
                        </Typography>
                        <OnOffSwitch
                            label="Include Phased Out"
                            value={includePhasedOut}
                            onChange={this.handleChange}
                            propertyName="includePhasedOut"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <OnOffSwitch
                            label="Cartonised Only"
                            value={cartonisedOnly}
                            onChange={this.handleChange}
                            propertyName="cartonisedOnly"
                        />
                    </Grid>
                    <Button variant="outlined" onClick={() => this.handleClick()}>
                        Run Report
                    </Button>
                </Grid>
            </Page>
        );
    }
}

EanCodesOptions.propTypes = {
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    prevOptions: PropTypes.shape({
        includePhasedOut: PropTypes.bool,
        cartonisedOnly: PropTypes.bool
    })
};

EanCodesOptions.defaultProps = {
    prevOptions: {}
};

export default EanCodesOptions;
