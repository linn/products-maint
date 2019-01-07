import React, { Component } from 'react';
import Button from '@material-ui/core/Button';
import { withStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';

const styles = theme => ({
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
        const {classes } = this.props;
        return (
            <div className={classes.root}>
                <Grid container spacing={24} justify="center">

                    <Grid item xs={12}>
                    <h4>Ean Codes of Sales Articles Report Options</h4>
                        <FormControlLabel
                            control={
                                <Checkbox
                                    checked={this.state.includePhasedOut}
                                    onChange={ch => this.handlePhaseOutChange(ch.target.checked)}
                                    value={this.state.includePhasedOut}
                                    color="primary"
                                />
                            }
                            label="Include phased out"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <FormControlLabel
                            control={
                                <Checkbox
                                    checked={this.state.cartonisedOnly}
                                    onChange={ch => this.handleCartonisedOnlyChange(ch.target.checked)}
                                    value={this.state.cartonisedOnly}
                                    color="primary"
                                />
                            }
                            label="Cartonised Only"
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