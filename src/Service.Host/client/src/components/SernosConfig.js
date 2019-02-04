import React, { Component, Fragment } from 'react';
import { Link } from 'react-router-dom';
import { Typography, TextField, Paper, Button, MenuItem, Grid } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import { ErrorCard } from '@linn-it/linn-form-components-library';
import CircularLoading from './common/CircularLoading';
import { getSelfHref } from '../helpers/utilities';

const styles = () => ({
    root: {
        margin: '40px',
        padding: '40px'
    },
    label: {
        fontWeight: 'bold'
    },
    fullWidth: {
        width: '100%'
    },
    gridItem: {
        paddingLeft: 12,
        paddingRight: 12
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
            sernosConfig: {
                name: '',
                description: '',
                serialNumbered: '',
                numberOfSernos: '',
                numberOfBoxes: '',
                startOn: ''
            },
            editStatus: this.props.editStatus || 'edit',
            edited: false
        };
    }

    static getDerivedStateFromProps(nextProps, prevState) {
        return getSelfHref(nextProps.sernosConfig) !== getSelfHref(prevState.sernosConfig)
            ? {
                sernosConfig: nextProps.sernosConfig,
                editStatus: nextProps.editStatus
            }
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

        const startOnOptions = ['', 'Any', 'Odd', 'Even'];
        const serialNumberedOptions = ['', 'Y', 'N'];

        return (
            <Paper className={classes.root}>
                {loading || !sernosConfig
                    ? errorMessage
                        ? <ErrorCard errorMessage={errorMessage} />
                        : <CircularLoading />
                    : (
                        <Fragment>
                            <Grid container spacing={0}>
                                <Grid item xs={12}>
                                    <Typography variant='h3' align='center' gutterBottom>
                                        Sernos Config
                                    </Typography>
                                </Grid>
                                <Grid item xs={6} className={classes.gridItem}>
                                    <TextField
                                        className={classes.fullWidth}
                                        name='name'
                                        label='Name'
                                        value={this.state.sernosConfig.name}
                                        margin='normal'
                                        variant='filled'
                                        onChange={e => this.handleChange(e, 'name')}
                                    />
                                </Grid>
                                <Grid item xs={6} className={classes.gridItem}>
                                    <TextField
                                        className={`${classes.fullWidth} `}
                                        name='description'
                                        label='Description'
                                        value={this.state.sernosConfig.description}
                                        margin='normal'
                                        variant='filled'
                                        onChange={e => this.handleChange(e, 'description')}
                                    />
                                </Grid>
                                <Grid item xs={6} className={classes.gridItem} justify="center">
                                    <TextField
                                        className={`${classes.fullWidth} `}
                                        label="Serial Numbered"
                                        value={this.state.sernosConfig.serialNumbered}
                                        onChange={e => this.handleChange(e, 'serialNumbered')}
                                        margin='normal'
                                        variant="filled"
                                        select
                                    >
                                        {serialNumberedOptions.map(option => (
                                            <MenuItem key={option} value={option}>
                                                {option}
                                            </MenuItem>
                                        ))}
                                    </TextField>
                                </Grid>
                                <Grid item xs={6} className={classes.gridItem}>
                                    <TextField
                                        className={`${classes.fullWidth} `}
                                        name='numberOfSernos'
                                        label='Number of Serial Nos'
                                        value={this.state.sernosConfig.numberOfSernos}
                                        margin='normal'
                                        variant='filled'
                                        type='number'
                                        onChange={e => this.handleChange(e, 'numberOfSernos')}
                                    />
                                </Grid>
                                <Grid item xs={6} className={classes.gridItem}>
                                    <TextField
                                        className={`${classes.fullWidth} `}
                                        name='numberOfBoxes'
                                        label='Number of Serial Boxes'
                                        value={this.state.sernosConfig.numberOfBoxes}
                                        margin='normal'
                                        variant='filled'
                                        type='number'
                                        onChange={e => this.handleChange(e, 'numberOfBoxes')}
                                        style={{ paddingBottom: 10 }}
                                    />
                                </Grid>
                                <Grid item xs={6} className={classes.gridItem}>
                                    <TextField
                                        className={`${classes.fullWidth} `}
                                        label="Start On"
                                        value={this.state.sernosConfig.startOn}
                                        onChange={e => this.handleChange(e, 'startOn')}
                                        margin='normal'
                                        select
                                        variant="filled"
                                    >
                                        {startOnOptions.map(option => (
                                            <MenuItem key={option} value={option}>
                                                {option}
                                            </MenuItem>
                                        ))}
                                    </TextField>
                                </Grid>
                                <Grid item xs={12} className={classes.gridItem}>
                                    <Button
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
                                            id="save-button"
                                            color="secondary"
                                            disabled={!this.state.edited}
                                        >
                                            Save
                                        </Button>
                                    </div>
                                </Grid>
                            </Grid>
                            {errorMessage && <ErrorCard errorMessage={errorMessage} />}
                        </Fragment>
                    )
                }
            </Paper>
        );
    }
}

export default withStyles(styles)(SernosConfig);

