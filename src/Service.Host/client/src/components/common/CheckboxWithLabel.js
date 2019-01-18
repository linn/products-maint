import React from 'react';
import { FormControlLabel, Checkbox } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';

const styles = {
    root: {
        width: '100%',
    }
}

const CheckboxWithLabel = ({ classes, checked, color = 'primary', label, onChange }) => (
    <FormControlLabel
        label={label}
        classes={{ label: `${classes.root}` }}
        style={{ marginLeft: 0, paddingLeft: 0 }}
        labelPlacement='start'
        control={
            <Checkbox
                checked={checked}
                onChange={onChange}
                color={color}
            />
        }
    />
)

export default withStyles(styles)(CheckboxWithLabel);