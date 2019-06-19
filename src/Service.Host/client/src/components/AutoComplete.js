import React, { useState } from 'react';
import PropTypes from 'prop-types';
import Select from 'react-select';
import { makeStyles } from '@material-ui/styles';
import { Typography, TextField, MenuItem, Paper } from '@material-ui/core';

const useStyles = makeStyles(theme => ({
    root: {
        flexGrow: 1
    },
    input: {
        display: 'flex',
        padding: 8
    },
    valueContainer: {
        display: 'flex',
        flexWrap: 'wrap',
        flex: 1,
        alignItems: 'center',
        overflow: 'hidden'
    },
    noOptionsMessage: {
        //padding: `${theme.spacing(1)}px ${theme.spacing(2)}px` TODO
    },
    singleValue: {
        fontSize: 16
    },
    placeholder: {
        position: 'absolute',
        left: 2,
        fontSize: 16
    },
    paper: {
        position: 'absolute',
        zIndex: 200,
        //marginTop: theme.spacing(1),
        left: 0,
        right: 0
    },
    divider: {
        //height: theme.spacing(2)
    },
    primary: {
        //color: theme.palette.text.primary
    }
}));

function NoOptionsMessage(props) {
    const { innerProps, children } = props;
    const classes = useStyles();
    return (
        <Typography color="textSecondary" className={classes.noOptionsMessage} {...innerProps}>
            {children}
        </Typography>
    );
}

function inputComponent({ inputRef, ...props }) {
    return <div ref={inputRef} {...props} />;
}

function Control(props) {
    const { selectProps, innerRef, children, innerProps, error } = props;
    const classes = useStyles();

    return (
        <TextField
            error={error}
            fullWidth
            margin="normal"
            variant="outlined"
            InputLabelProps={{ shrink: true }}
            label={selectProps.label}
            InputProps={{
                inputComponent,
                inputProps: {
                    className: classes.input,
                    inputRef: innerRef,
                    children,
                    ...innerProps
                }
            }}
            {...selectProps.textFieldProps}
        />
    );
}

function Option(props) {
    const { innerRef, isFocused, innerProps, children } = props;
    return (
        <MenuItem buttonRef={innerRef} selected={isFocused} component="div" {...innerProps}>
            {children}
        </MenuItem>
    );
}

function Placeholder(props) {
    const { innerProps, children } = props;
    const classes = useStyles();
    return (
        <Typography color="textSecondary" className={classes.placeholder} {...innerProps}>
            {children}
        </Typography>
    );
}

function SingleValue(props) {
    const { innerProps, children } = props;
    const classes = useStyles();

    return (
        <Typography className={classes.singleValue} {...innerProps}>
            {children}
        </Typography>
    );
}

function ValueContainer(props) {
    const { selectProps, children } = props;
    const classes = useStyles();

    return <div className={classes.valueContainer}>{children}</div>;
}

function Menu(props) {
    const { innerProps, children } = props;
    const classes = useStyles();

    return (
        <Paper square className={classes.paper} {...innerProps}>
            {children}
        </Paper>
    );
}

const components = {
    Control,
    Menu,
    NoOptionsMessage,
    Option,
    Placeholder,
    SingleValue,
    ValueContainer
};

function AutoComplete(suggestions, disabled, label, onInputChange, isLoading) {
    const [single, setSingle] = useState(null);

    const handleChange = () => {
        setSingle('single');
    };

    const classes = useStyles();

    if (suggestions && suggestions.length === 1) {
        setSingle(suggestions[0]);
    }

    const selectStyles = {
        input: base => ({
            ...base,
            color: classes.primary,
            '& input': {
                font: 'inherit'
            }
        })
    };

    return (
        <div className={classes.root}>
            <Select
                isDisabled={disabled}
                classes={classes}
                styles={selectStyles}
                options={suggestions}
                label={label}
                components={components}
                placeholder=""
                onInputChange={onInputChange}
                value={suggestions && suggestions.length === 1 ? suggestions[0] : single}
                onChange={handleChange}
                isClearable
                isLoading={isLoading}
            />
        </div>
    );
}

AutoComplete.defaultProps = {
    disabled: false,
    onInputChange: undefined,
    suggestions: [],
    isLoading: false
};

AutoComplete.propTypes = {
    classes: PropTypes.shape({}).isRequired,
    theme: PropTypes.shape({}).isRequired,
    suggestions: PropTypes.arrayOf(PropTypes.shape),
    propertyName: PropTypes.string.isRequired,
    disabled: PropTypes.bool,
    label: PropTypes.string.isRequired,
    onChange: PropTypes.func.isRequired,
    onInputChange: PropTypes.func,
    isLoading: PropTypes.bool
};

export default AutoComplete;
