import React, { Component } from 'react';
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles';
import InputAdornment from '@material-ui/core/InputAdornment';

const styles = theme => ({
    boldHeader: {
        fontWeight: 'bold',
        width: '140px'
    },
    biggerText: {
        fontSize: 14
    },
    fontSize18: {
        fontSize: 18
    },
    shortWidth: {
        width: '30%'
    },
    halfWidth: {
        width: '50%'
    },
    threeQuartersWidth: {
        width: '75%'
    },
    fullWidth: {
        width: '100%'
    }
});

class TextInput extends Component {

    constructor(props) {
        super(props);
        this.state = {
            value: this.props.value,
            required: this.props.required || false
        };
    }

    valid() {
        const { value, required } = this.props;

        if (required && !value) {
            return false;
        }

        return true;
    }

    onChange(e) {
        const { changeState, propertyName } = this.props;

        this.state.value = e.target.value;
        if (changeState) {
            changeState(propertyName, e.target.value);
        }
    }

    getControlClassname() {
        const { classes, width } = this.props;

        switch (width) {
            case "short":
                return classes.shortWidth;
            case "half":
                return classes.halfWidth;
            case "full":
                return classes.fullWidth;
            default:
                return classes.threeQuartersWidth;
        }
    }

    inputStyling() {
        const { classes } = this.props;
        return {
            input: classes.biggerText
        }
    }

    endAdornment(suffix) {
        if (suffix) {
            return (<InputAdornment position = "start" > {suffix}</InputAdornment>);
        }
        return null;
    }

    buildInputProps() {
        const { suffix } = this.props;
        let inputProps = {}

        inputProps.classes = this.inputStyling();

        if (suffix) {
            inputProps.endAdornment = this.endAdornment(suffix);
        }

        return inputProps;
    }

    buildInputLabelProps() {
        const { classes, shrink, type } = this.props;
        let inputProps = {}

        inputProps.className = classes.fontSize18;

        if (shrink || (type === "date")) {
            inputProps.shrink = true;
        }

        return inputProps;
    }

    render() {
        const { label, value, placeholder, type } = this.props;

        return (
            <div>
                <TextField
                    className={this.getControlClassname()}
                    label={label}
                    defaultValue={value}
                    placeholder={placeholder}
                    type={type}
                    onChange={e => this.onChange(e)}
                    margin="normal"
                    variant="outlined"
                    InputProps={this.buildInputProps()}
                    InputLabelProps={this.buildInputLabelProps()}
                />
            </div>
        );
    }
}

export default withStyles(styles)(TextInput);