import React, { Component } from 'react';
import { withStyles } from '@material-ui/core/styles';
import { Button, Grid, Typography } from '@material-ui/core';
import { CheckboxWithLabel } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';

const styles = () => ({
    root: {
        flexGrow: 1,
        paddingLeft: '20%',
        paddingRight: '20%'
    }
});

class EanCodesOptions extends Component {
    constructor(props) {
        super(props);
        this.state = {
            includePhasedOut: props.prevOptions ? props.prevOptions.includePhasedOut : false,
            cartonisedOnly: props.prevOptions ? props.prevOptions.cartonisedOnly : true
        };
    }

    handlePhaseOutChange(checked) {
        this.setState({ includePhasedOut: checked });
    }

    handleCartonisedOnlyChange(checked) {
        this.setState({ cartonisedOnly: checked });
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
        const { classes } = this.props;
        const { includePhasedOut, cartonisedOnly } = this.state;

        return (
            <div className={classes.root}>
                <Grid style={{ marginTop: 40 }} container spacing={24} justify="center">
                    <Grid item xs={12}>
                        <Typography variant="h4" gutterBottom>
                            Ean Codes of Sales Articles Report Options
                        </Typography>
                        <CheckboxWithLabel
                            label="Include Phased Out"
                            checked={includePhasedOut}
                            onChange={e => this.handlePhaseOutChange(e.target.checked)}
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <CheckboxWithLabel
                            label="Cartonised Only"
                            checked={cartonisedOnly}
                            onChange={e => this.handleCartonisedOnlyChange(e.target.checked)}
                        />
                    </Grid>
                    <Button variant="outlined" bsClass="btn" onClick={() => this.handleClick()}>
                        Run Report
                    </Button>
                </Grid>
            </div>
        );
    }
}

EanCodesOptions.propTypes = {
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    classes: PropTypes.shape({}),
    prevOptions: PropTypes.shape({
        includePhasedOut: PropTypes.bool,
        cartonisedOnly: PropTypes.bool
    })
};

EanCodesOptions.defaultProps = {
    classes: {},
    prevOptions: {}
};

export default withStyles(styles)(EanCodesOptions);
