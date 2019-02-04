import React, { Component } from 'react';
import Button from '@material-ui/core/Button';
import { withStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import PropTypes from 'prop-types';

const styles = () => ({
    root: {
        flexGrow: 1,
        paddingLeft: '20%',
        paddingRight: '20%'
    }
});

class ProductRangesOptions extends Component {
    constructor(props) {
        super(props);
        this.state = {
            includePhasedOut: props.prevOptions ? props.prevOptions.includePhasedOut : false
        };
    }

    handlePhaseOutChange(checked) {
        this.setState({ includePhasedOut: checked });
    }

    handleClick() {
        const { history } = this.props;
        const { includePhasedOut } = this.state;

        history.push({
            pathname: `/products/reports/product-ranges/report`,
            search: `?includePhasedOut=${includePhasedOut}`
        });
    }

    render() {
        const { classes } = this.props;
        const { includePhasedOut } = this.state;
        return (
            <div className={classes.root}>
                <Grid container spacing={24} justify="center">
                    <Grid item xs={12}>
                        <h4>Ean Codes of Sales Articles Report Options</h4>
                        <FormControlLabel
                            control={
                                <Checkbox
                                    checked={includePhasedOut}
                                    onChange={ch => this.handlePhaseOutChange(ch.target.checked)}
                                    value={includePhasedOut}
                                    color="primary"
                                />
                            }
                            label="Include phased out"
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

ProductRangesOptions.propTypes = {
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    classes: PropTypes.shape({}),
    prevOptions: PropTypes.shape({
        includePhasedOut: PropTypes.bool,
        cartonisedOnly: PropTypes.bool
    })
};

ProductRangesOptions.defaultProps = {
    classes: {},
    prevOptions: {}
};

export default withStyles(styles)(ProductRangesOptions);
