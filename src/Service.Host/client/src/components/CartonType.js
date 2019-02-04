import React, { Component, Fragment } from 'react';
import { Link } from 'react-router-dom';
import { Typography, TextField, Paper, Button } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import { ErrorCard } from '@linn-it/linn-form-components-library';
import CircularLoading from './common/CircularLoading';
import { getSelfHref } from '../helpers/utilities';

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

class CartonType extends Component {
    constructor(props) {
        super(props);
        this.state = {
            cartonType: this.props.cartonType || {},
            editStatus: this.props.editStatus || 'edit',
            edited: false
        };
    }

    static getDerivedStateFromProps(nextProps, prevState) {
        return getSelfHref(nextProps.cartonType) !== getSelfHref(prevState.cartonType)
            ? { cartonType: nextProps.cartonType }
            : null;
    }

    handleChange(e, property) {
        this.setState({
            ...this.state,
            edited: true,
            cartonType: {
                ...this.state.cartonType,
                [property]: e.target.value
            }
        });
    }

    handleCancelClick() {
        const { cartonType, history, resetCartonType } = this.props;
        resetCartonType();
        this.state.editStatus === 'create'
            ? history.push('/products/reports/carton-details/report')
            : this.setState({ cartonType, editStatus: 'edit', edited: false });
    }

    handleSaveClick() {
        const { cartonTypeId, addCartonType, updateCartonType } = this.props;
        this.state.editStatus === 'create'
            ? addCartonType(this.state.cartonType)
            : updateCartonType(cartonTypeId, this.state.cartonType);
    }

    render() {
        const { cartonType, loading, classes, errorMessage } = this.props;

        return (
            <Paper className={classes.root}>
                {loading || !cartonType
                    ? <CircularLoading />
                    : (
                        <Fragment>
                            <Typography
                                variant="h2"
                                align="center"
                                gutterBottom
                            >
                                Carton Type
                            </Typography>
                            <TextField
                                className={classes.fullWidth}
                                name="name"
                                label="Name"
                                value={this.state.cartonType.name || ''}
                                margin="normal"
                                variant="filled"
                                InputProps={{
                                    className: classes.fontOverride
                                }}
                                InputLabelProps={{
                                    className: classes.fontOverride
                                }}
                                onChange={e => this.handleChange(e, 'name')}
                            />
                            <TextField
                                className={classes.fullWidth}
                                name="description"
                                label="Description"
                                value={this.state.cartonType.description || ''}
                                margin="normal"
                                variant="filled"
                                InputProps={{
                                    className: classes.fontOverride
                                }}
                                InputLabelProps={{
                                    className: classes.fontOverride
                                }}
                                onChange={e => this.handleChange(e, 'description')}
                            />
                            <TextField
                                className={classes.fullWidth}
                                name="width"
                                label="Width"
                                type="number"
                                value={this.state.cartonType.width || ''}
                                margin="normal"
                                variant="filled"
                                InputProps={{
                                    className: classes.fontOverride
                                }}
                                InputLabelProps={{
                                    className: classes.fontOverride
                                }}
                                onChange={e => this.handleChange(e, 'width')}
                            />
                            <TextField
                                className={classes.fullWidth}
                                name="height"
                                label="Height"
                                type="number"
                                value={this.state.cartonType.height || ''}
                                margin="normal"
                                variant="filled"
                                InputProps={{
                                    className: classes.fontOverride
                                }}
                                InputLabelProps={{
                                    className: classes.fontOverride
                                }}
                                onChange={e => this.handleChange(e, 'height')}
                            />
                            <TextField
                                className={classes.fullWidth}
                                name="depth"
                                label="Depth"
                                type="number"
                                value={this.state.cartonType.depth || ''}
                                margin="normal"
                                variant="filled"
                                InputProps={{
                                    className: classes.fontOverride
                                }}
                                InputLabelProps={{
                                    className: classes.fontOverride
                                }}
                                onChange={e => this.handleChange(e, 'depth')}
                            />
                            <div style={{ marginTop: '10px' }}>
                                <Button
                                    className={classes.fontOverride}
                                    id="back-button"
                                    component={Link}
                                    to="/products/reports/carton-details/report"
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
                                        disabled={!this.state.edited}
                                        onClick={() => this.handleCancelClick()}
                                    >
                                        Cancel
                                    </Button>
                                    <Button
                                        className={classes.fontOverride}
                                        id="save-button"
                                        color="secondary"
                                        variant="outlined"
                                        disabled={!this.state.edited}
                                        onClick={() => this.handleSaveClick()}
                                    >
                                        Save
                                    </Button>
                                </div>
                            </div>
                            {errorMessage && <ErrorCard errorMessage={errorMessage} />}
                        </Fragment>
                    )
                }
            </Paper>
        );
    }
}

export default withStyles(styles)(CartonType);