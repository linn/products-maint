import React, { Component } from 'react';
import Button from '@material-ui/core/Button';
import { withStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import PropTypes from 'prop-types';

const styles = () => ({
    root: {
        flexGrow: 1,
        paddingLeft: '20%',
        paddingRight: '20%'
    }
});

class CartonDetailsOptions extends Component {
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
        const { includePhasedOut, cartonisedOnly } = this.state;

        history.push({
            pathname: `/products/reports/carton-details/report`,
            search: `?includePhasedOut=${includePhasedOut}&cartonisedOnly=${cartonisedOnly}`
        });
    }

    render() {
        const { classes } = this.props;
        return (
            <div className={classes.root}>
                <Grid container spacing={24} justify="center">
                    <Button variant="outlined" bsClass="btn" onClick={() => this.handleClick()}>
                        Run Report
                    </Button>
                </Grid>
            </div>
        );
    }
}

CartonDetailsOptions.propTypes = {
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    classes: PropTypes.shape({}),
    prevOptions: PropTypes.shape({
        includePhasedOut: PropTypes.bool,
        cartonisedOnly: PropTypes.bool
    })
};

CartonDetailsOptions.defaultProps = {
    classes: {},
    prevOptions: {}
};

export default withStyles(styles)(CartonDetailsOptions);
