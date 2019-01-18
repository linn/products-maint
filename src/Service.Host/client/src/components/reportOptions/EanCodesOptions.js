import React, { Component } from 'react';
import { withStyles } from '@material-ui/core/styles';
import { Button, Grid, Typography } from '@material-ui/core';
import CheckboxWithLabel from '../common/CheckboxWithLabel';

const styles = () => ({
    root: {
        flexGrow: 1,
        paddingLeft: "20%",
        paddingRight: "20%",
    },
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

        history.push(
            {
                pathname: `/products/reports/sales-article-ean-codes/report`,
                search: `?includePhasedOut=${this.state.includePhasedOut}&cartonisedOnly=${this.state.cartonisedOnly}`
            }
        );
    }

    render() {
        const { classes } = this.props;
        return (
            <div className={classes.root}>
                <Grid style={{ marginTop: 40 }} container spacing={24} justify="center">
                    <Grid item xs={12}>
                        <Typography variant='h4' gutterBottom>Ean Codes of Sales Articles Report Options</Typography>
                        <CheckboxWithLabel
                            label='Include Phased Out'
                            checked={this.state.includePhasedOut}
                            onChange={e => this.handlePhaseOutChange(e.target.checked)}
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <CheckboxWithLabel
                            label='Cartonised Only'
                            checked={this.state.cartonisedOnly}
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

export default withStyles(styles)(EanCodesOptions);