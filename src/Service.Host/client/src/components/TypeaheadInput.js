import React, { Component, Fragment } from 'react';
import { withStyles } from '@material-ui/core/styles';
import List from '@material-ui/core/List';
import { ListItem, InputAdornment, TextField, Typography } from '@material-ui/core';
import PropTypes from 'prop-types';
import { Title, Loading } from '@linn-it/linn-form-components-library';

const styles = theme => ({
    paper: {
        padding: theme.spacing.unit * 6
    },
    boldHeader: {
        fontWeight: 'bold',
        width: '140px'
    },
    pullRight: {
        float: 'right'
    },
    halfWidth: {
        width: '50%'
    },
    biggerText: {
        fontSize: 14
    },
    a: {
        textDecoration: 'none'
    }
});

const Results = ({ items }) => {
    const onSelect = arg => alert(arg);

    if (items.length > 0) {
        return (
            <List>
                {items.map(item => (
                    <ListItem key={item.id} button onClick={() => onSelect(item.name)}>
                        <Typography style={{ fontWeight: 600, width: 140 }}>{item.name}</Typography>
                        <Typography>{item.description}</Typography>
                    </ListItem>
                ))}
            </List>
        );
    }
    return <Typography>No matching items</Typography>;
};

function TypeaheadInput({
    fetchItems,
    clearSearch,
    items,
    classes,
    loading,
    title,
    value,
    onChange
}) {
    return (
        <Fragment>
            <Title text={title} />
            <TextField
                className={classes.halfWidth}
                value={value}
                placeholder="Search by id or description"
                onChange={onChange}
                type="search"
                margin="normal"
                variant="outlined"
                InputProps={{
                    classes: {
                        input: classes.biggerText
                    },
                    startAdornment: (
                        <InputAdornment position="start">
                            <svg
                                xmlns="http://www.w3.org/2000/svg"
                                width="24"
                                height="24"
                                viewBox="0 0 24 24"
                            >
                                <path d="M15.5 14h-.79l-.28-.27C15.41 12.59 16 11.11 16 9.5 16 5.91 13.09 3 9.5 3S3 5.91 3 9.5 5.91 16 9.5 16c1.61 0 3.09-.59 4.23-1.57l.27.28v.79l5 4.99L20.49 19l-4.99-5zm-6 0C7.01 14 5 11.99 5 9.5S7.01 5 9.5 5 14 7.01 14 9.5 11.99 14 9.5 14z" />
                            </svg>
                        </InputAdornment>
                    )
                }}
            />
            {loading ? <Loading /> : <Results items={items} classes={classes} />}
        </Fragment>
    );
}

TypeaheadInput.propTypes = {
    items: PropTypes.arrayOf(
        PropTypes.shape({
            id: PropTypes.oneOfType([PropTypes.string, PropTypes.number]),
            name: PropTypes.string,
            description: PropTypes.string,
            href: PropTypes.string
        })
    ).isRequired,
    title: PropTypes.string,
    loading: PropTypes.bool,
    classes: PropTypes.shape({}).isRequired,
    fetchItems: PropTypes.func.isRequired,
    clearSearch: PropTypes.func.isRequired
};

TypeaheadInput.defaultProps = {
    title: '',
    loading: false
};

export default withStyles(styles)(TypeaheadInput);
