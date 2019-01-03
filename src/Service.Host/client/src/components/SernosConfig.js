﻿import React, { Component, Fragment } from 'react';
import { Link } from 'react-router-dom';
import { Typography, TextField, Paper, Button } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import ErrorCard from '../components/common/ErrorCard';
import CircularLoading from '../components/common/CircularLoading';
import CheckboxWithLabel from '../components/common/CheckboxWithLabel';
import Dropdown from '../components/common/Dropdown';
import { getSelfHref } from '../helpers/utilities'

const styles = () => ({
    root: {
        margin: 40,
        padding: 40
    },
    label: {
        fontWeight: 'bold'
    },
    fontOverride: {
        fontSize: 14
    },
    fullWidth: {
        width: '100%'
    },
    loading: {
        margin: 'auto'
    },
    pullRight: {
        float: 'right'
    }
});

class SernosConfig extends Component {
    constructor(props) {
        super(props);
        this.state = {
            sernosConfig: this.props.sernosConfig || {},
            editStatus: this.props.editStatus || 'edit',
            edited: false
        };
    }
    
    static getDerivedStateFromProps(nextProps, prevState) {
        return getSelfHref(nextProps.sernosConfig) !== getSelfHref(prevState.sernosConfig)
            ? { sernosConfig: nextProps.sernosConfig }
            : null;
    }

    handleCancelClick() {
        const { sernosConfig, history, resetSernosConfig } = this.props;
        resetSernosConfig();
        this.state.editStatus === 'create'
            ? history.push('/products/maint/sernos-cofigs')
            : this.setState({ sernosConfig, edited: false });
    }

    handleSaveClick() {
        const { sernosConfigId, addSernosConfig, updateSernosConfig } = this.props;
        this.state.editStatus === 'create'
            ? addSernosConfig(this.state.sernosConfig)
            : updateSernosConfig(sernosConfigId, this.state.sernosConfig);
    }

    handleChange(e, property) {
        this.setState({
            ...this.state,
            edited: true,
            sernosConfig: {
                ...this.state.sernosConfig,
                [property]: e.target.value
            }
        });
    }

    handleCheckboxChange(e, property) {
        this.setState({
            ...this.state,
            edited: true,
            sernosConfig: {
                ...this.state.sernosConfig,
                [property]: e.target.checked ? 'Y' : 'N'
            }
        });
    }

    render() {
        const { sernosConfig, loading, errorMessage, classes } = this.props;

        return (
            <Paper className={classes.root}>
                {loading || !sernosConfig
                    ? errorMessage
                        ? <ErrorCard errorMessage={errorMessage} />
                        : <CircularLoading />
                    : (
                        <Fragment>
                            <Typography variant='h2' align='center' gutterBottom>
                                Sernos Config
                            </Typography>
                            <TextField
                                className={classes.fullWidth}
                                name='name'
                                label='Name'
                                value={this.state.sernosConfig.name}
                                margin='normal'
                                variant='filled'
                                InputProps={{
                                    className: classes.fontOverride
                                }}
                                InputLabelProps={{
                                    className: classes.fontOverride
                                }}
                                onChange={e => this.handleChange(e, 'name')}
                            />
                            <TextField
                                className={`${classes.fullWidth} ${classes.fontOverride}`}
                                name='description'
                                label='Description'
                                value={this.state.sernosConfig.description}
                                margin='normal'
                                variant='filled'
                                InputProps={{
                                    className: classes.fontOverride
                                }}
                                InputLabelProps={{
                                    className: classes.fontOverride
                                }}
                                onChange={e => this.handleChange(e, 'description')}
                            />
                            <CheckboxWithLabel
                                label='Serial Numbered'
                                checked={this.state.sernosConfig.serialNumbered === 'Y' ? true : false}
                                onChange={e => this.handleCheckboxChange(e, 'serialNumbered')}
                            />
                            <TextField
                                className={`${classes.fullWidth} ${classes.fontOverride}`}
                                name='numberOfSernos'
                                label='Number of Serial Nos'
                                value={this.state.sernosConfig.numberOfSernos}
                                margin='normal'
                                variant='filled'
                                type='number'
                                InputProps={{
                                    className: classes.fontOverride
                                }}
                                InputLabelProps={{
                                    className: classes.fontOverride
                                }}
                                onChange={e => this.handleChange(e, 'numberOfSernos')}
                            />
                            <TextField
                                className={`${classes.fullWidth} ${classes.fontOverride}`}
                                name='numberOfBoxes'
                                label='Number of Serial Boxes'
                                value={this.state.sernosConfig.numberOfBoxes}
                                margin='normal'
                                variant='filled'
                                type='number'
                                InputProps={{
                                    className: classes.fontOverride
                                }}
                                InputLabelProps={{
                                    className: classes.fontOverride
                                }}
                                onChange={e => this.handleChange(e, 'numberOfBoxes')}
                            />
                            <Dropdown
                                label='Start On'
                                items={['', 'Any', 'Odd', 'Even']}
                                onChange={e => this.handleChange(e, 'startOn')}
                                value={this.state.sernosConfig.startOn}
                            />
                            <Button
                                className={classes.fontOverride}
                                id="back-button"
                                component={Link}
                                to="/products/maint/sernos-configs"
                                variant="outlined"
                            >
                                Back
                            </Button>
                            <div className={classes.pullRight}>
                                <Button
                                    style={{ marginRight: '10px' }}
                                    className={classes.fontOverride}
                                    id="cancel-button"
                                    color="primary"
                                    variant="outlined"
                                    onClick={() => this.handleCancelClick()}
                                    disabled={!this.state.edited}
                                >
                                    Cancel
                                </Button>
                                <Button
                                    onClick={() => this.handleSaveClick()}
                                    className={classes.fontOverride}
                                    id="save-button"
                                    variant="outlined"
                                    color="secondary"
                                    disabled={!this.state.edited}
                                >
                                    Save
                            </Button>
                            </div>

                            {errorMessage && <ErrorCard errorMessage={errorMessage} />}
                        </Fragment>
                    )
                }
            </Paper>
        );
    }
}

export default withStyles(styles)(SernosConfig);

