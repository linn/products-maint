import React, { Component, Fragment } from 'react';
import { Link } from 'react-router-dom';
import { Typography, TextField, Paper, Button } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import ErrorCard from '../components/common/ErrorCard';
import CircularLoading from '../components/common/CircularLoading';
import CheckboxWithLabel from '../components/common/CheckboxWithLabel';
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

class TypeOfSale extends Component {
    constructor(props) {
        super(props);
        this.state = {
            typeOfSale: this.props.sernosConfig || {},
            editStatus: this.props.editStatus || 'edit',
            edited: false
        };
    }

    static getDerivedStateFromProps(nextProps, prevState) {
        return getSelfHref(nextProps.typeOfSale) !== getSelfHref(prevState.typeOfSale)
            ? { typeOfSale: nextProps.typeOfSale }
            : null;
    }

    handleCancelClick() {
        const { typeOfSale, history, resetTypeOfSale } = this.props;
        resetTypeOfSale();
        this.state.editStatus === 'create'
            ? history.push('/products/maint/types-of-sale')
            : this.setState({ typeOfSale, edited: false });
    }

    handleSaveClick() {
        const { typeOfSaleId, addTypeOfSale, updateTypeOfSale } = this.props;
        this.state.editStatus === 'create'
            ? addTypeOfSale(this.state.typeOfSale)
            : updateTypeOfSale(typeOfSaleId, this.state.typeOfSale);
    }

    handleChange(e, property) {
        this.setState({
            ...this.state,
            edited: true,
            typeOfSale: {
                ...this.state.typeOfSale,
                [property]: e.target.value
            }
        });
    }

    handleCheckboxChange(e, property) {
        this.setState({
            ...this.state,
            edited: true,
            typeOfSale: {
                ...this.state.typeOfSale,
                [property]: e.target.checked ? 'Y' : 'N'
            }
        });
    }

    render() {
        const { typeOfSale, loading, errorMessage, classes } = this.props;

        return (
            <Paper className={classes.root}>
                {loading || !typeOfSale
                    ? errorMessage
                        ? <ErrorCard errorMessage={errorMessage} />
                        : <CircularLoading />
                    : (
                        <Fragment>
                            <Typography variant='h2' align='center' gutterBottom>
                                Type of Sale
                            </Typography>
                            <TextField
                                className={classes.fullWidth}
                                name='name'
                                label='Name'
                                value={this.state.typeOfSale.name || ''}
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
                                className={classes.fullWidth}
                                name='description'
                                label='Description'
                                value={this.state.typeOfSale.description || ''}
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
                            <TextField
                                className={classes.fullWidth}
                                name='department'
                                label='Department'
                                value={this.state.typeOfSale.department || ''}
                                margin='normal'
                                variant='filled'
                                InputProps={{
                                    className: classes.fontOverride
                                }}
                                InputLabelProps={{
                                    className: classes.fontOverride
                                }}
                                onChange={e => this.handleChange(e, 'department')}
                            />
                            <TextField
                                className={classes.fullWidth}
                                name='nominal'
                                label='Nominal'
                                value={this.state.typeOfSale.nominal || ''}
                                margin='normal'
                                variant='filled'
                                InputProps={{
                                    className: classes.fontOverride
                                }}
                                InputLabelProps={{
                                    className: classes.fontOverride
                                }}
                                onChange={e => this.handleChange(e, 'nominal')}
                            />
                            <CheckboxWithLabel
                                label='Real Sale'
                                checked={this.state.typeOfSale.realSale === 'Y' ? true : false}
                                onChange={e => this.handleCheckboxChange(e, 'realSale')}
                            />
                            <div style={{ display: 'block' }}>
                                <Button
                                    className={classes.fontOverride}
                                    id="back-button"
                                    component={Link}
                                    to="/products/maint/types-of-sale"
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
                            </div>

                            {errorMessage && <ErrorCard errorMessage={errorMessage} />}
                        </Fragment>
                    )
                }
            </Paper>
        )
    }
}

export default withStyles(styles)(TypeOfSale);