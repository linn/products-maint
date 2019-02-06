import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Grid } from '@material-ui/core';
import {
    OnOffSwitch,
    SaveBackCancelButtons,
    InputField,
    Loading,
    Title,
    ErrorCard
} from '@linn-it/linn-form-components-library';
import Page from '../containers/Page';

class TypeOfSale extends Component {
    constructor(props) {
        super(props);
        this.handleFieldChange = this.handleFieldChange.bind(this);
        this.handleSwitchChange = this.handleSwitchChange.bind(this);
        this.state = {
            editStatus: 'view',
            typeOfSale: null
        };
    }

    static getDerivedStateFromProps(props, state) {
        if (!state.typeOfSale && props.typeOfSale) {
            return { typeOfSale: props.typeOfSale };
        }
        return null;
    }

    handleSaveClick = () => {
        const { typeOfSaleId, updateTypeOfSale } = this.props;
        updateTypeOfSale(typeOfSaleId, { ...this.state }.typeOfSale);
        this.setState({ editStatus: 'view' });
    };

    handleCancelClick = () => {
        const { typeOfSale } = this.props;
        this.setState({ typeOfSale });
        this.setState({ editStatus: 'view' });
    };

    handleAddClick = () => {
        const { addTypeOfSale } = this.props;
        const { typeOfSale } = this.state;
        addTypeOfSale(typeOfSale);
        this.setState({ editStatus: 'view' });
    };

    handleBackClick = () => {
        this.setState({ editStatus: 'view' });
        const { history } = this.props;
        history.push('/products/maint/types-of-sale');
    };

    creating() {
        const { editStatus } = this.props;
        return editStatus === 'create';
    }

    editing() {
        const { editStatus } = this.state;
        return editStatus === 'edit';
    }

    viewing() {
        const { editStatus } = this.state;
        return editStatus === 'view';
    }

    handleFieldChange(propertyName, val) {
        this.setState(prevState => ({
            typeOfSale: {
                ...prevState.typeOfSale,
                [propertyName]: val
            },
            editStatus: 'edit'
        }));
    }

    handleSwitchChange(propertyName, val) {
        this.setState(prevState => ({
            typeOfSale: {
                ...prevState.typeOfSale,
                [propertyName]: val ? 'Y' : 'N'
            },
            editStatus: 'edit'
        }));
    }

    render() {
        const { loading, errorMessage } = this.props;
        const { typeOfSale } = this.state;
        if (loading || !typeOfSale) {
            return <Loading />;
        }

        return (
            <Page>
                <Grid container spacing={24}>
                    <Grid item xs={12}>
                        {this.creating() ? (
                            <Title text="Create Type of Sale" />
                        ) : (
                            <Title text="Type of Sale Details" />
                        )}
                    </Grid>
                    {errorMessage && (
                        <Grid item xs={12}>
                            <ErrorCard errorMessage={errorMessage} />
                        </Grid>
                    )}
                    <Grid item xs={4}>
                        <InputField
                            fullWidth
                            disabled={!this.creating()}
                            value={typeOfSale.name}
                            label="Name"
                            helperText={
                                !this.creating()
                                    ? 'This field cannot be changed'
                                    : 'This field is required'
                            }
                            onChange={this.handleFieldChange}
                            propertyName="name"
                        />
                    </Grid>
                    <Grid item xs={8}>
                        <InputField
                            value={typeOfSale.description}
                            label="Description"
                            fullWidth
                            onChange={this.handleFieldChange}
                            propertyName="description"
                        />
                    </Grid>
                    <Grid item xs={8}>
                        <InputField
                            value={typeOfSale.department}
                            label="Department"
                            fullWidth
                            onChange={this.handleFieldChange}
                            propertyName="department"
                        />
                    </Grid>
                    <Grid item xs={8}>
                        <InputField
                            value={typeOfSale.nominal}
                            label="Nominal"
                            fullWidth
                            onChange={this.handleFieldChange}
                            propertyName="nominal"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <OnOffSwitch
                            label="Real Sale"
                            value={typeOfSale.realSale === 'Y'}
                            onChange={this.handleSwitchChange}
                            propertyName="realSale"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <SaveBackCancelButtons
                            saveDisabled={
                                !this.editing() ||
                                (!typeOfSale.name || typeOfSale.name.length === 0)
                            }
                            saveClick={this.creating() ? this.handleAddClick : this.handleSaveClick}
                            cancelClick={this.handleCancelClick}
                            backClick={this.handleBackClick}
                        />
                    </Grid>
                </Grid>
            </Page>
        );
    }
}

TypeOfSale.defaultProps = {
    typeOfSale: {},
    addTypeOfSale: null,
    updateTypeOfSale: null,
    loading: null,
    errorMessage: '',
    typeOfSaleId: null
};

TypeOfSale.propTypes = {
    typeOfSale: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    typeOfSaleId: PropTypes.string,
    updateTypeOfSale: PropTypes.func,
    addTypeOfSale: PropTypes.func,
    loading: PropTypes.bool
};

export default TypeOfSale;

//     handleCheckboxChange(e, property) {
//         this.setState({
//             ...this.state,
//             edited: true,
//             typeOfSale: {
//                 ...this.state.typeOfSale,
//                 [property]: e.target.checked ? 'Y' : 'N'
//             }
//         });
//     }

//     render() {
//         const { typeOfSale, loading, errorMessage, classes } = this.props;

//         return (
//             <Paper className={classes.root}>
//                 {loading || !typeOfSale
//                     ? errorMessage
//                         ? <ErrorCard errorMessage={errorMessage} />
//                         : <CircularLoading />
//                     : (
//                         <Fragment>
//                             <Typography variant='h2' align='center' gutterBottom>
//                                 Type of Sale
//                             </Typography>
//                             <TextField
//                                 className={classes.fullWidth}
//                                 name='name'
//                                 label='Name'
//                                 value={this.state.typeOfSale.name || ''}
//                                 margin='normal'
//                                 variant='filled'
//                                 InputProps={{
//                                     className: classes.fontOverride
//                                 }}
//                                 InputLabelProps={{
//                                     className: classes.fontOverride
//                                 }}
//                                 onChange={e => this.handleChange(e, 'name')}
//                             />
//                             <TextField
//                                 className={classes.fullWidth}
//                                 name='description'
//                                 label='Description'
//                                 value={this.state.typeOfSale.description || ''}
//                                 margin='normal'
//                                 variant='filled'
//                                 InputProps={{
//                                     className: classes.fontOverride
//                                 }}
//                                 InputLabelProps={{
//                                     className: classes.fontOverride
//                                 }}
//                                 onChange={e => this.handleChange(e, 'description')}
//                             />
//                             <TextField
//                                 className={classes.fullWidth}
//                                 name='department'
//                                 label='Department'
//                                 value={this.state.typeOfSale.department || ''}
//                                 margin='normal'
//                                 variant='filled'
//                                 InputProps={{
//                                     className: classes.fontOverride
//                                 }}
//                                 InputLabelProps={{
//                                     className: classes.fontOverride
//                                 }}
//                                 onChange={e => this.handleChange(e, 'department')}
//                             />
//                             <TextField
//                                 className={classes.fullWidth}
//                                 name='nominal'
//                                 label='Nominal'
//                                 value={this.state.typeOfSale.nominal || ''}
//                                 margin='normal'
//                                 variant='filled'
//                                 InputProps={{
//                                     className: classes.fontOverride
//                                 }}
//                                 InputLabelProps={{
//                                     className: classes.fontOverride
//                                 }}
//                                 onChange={e => this.handleChange(e, 'nominal')}
//                             />
//                             <CheckboxWithLabel
//                                 label='Real Sale'
//                                 checked={this.state.typeOfSale.realSale === 'Y' ? true : false}
//                                 onChange={e => this.handleCheckboxChange(e, 'realSale')}
//                             />
//                             <div style={{ display: 'block' }}>
//                                 <Button
//                                     className={classes.fontOverride}
//                                     id="back-button"
//                                     component={Link}
//                                     to="/products/maint/types-of-sale"
//                                     variant="outlined"
//                                 >
//                                     Back
//                                 </Button>
//                                 <div className={classes.pullRight}>
//                                     <Button
//                                         style={{ marginRight: '10px' }}
//                                         className={classes.fontOverride}
//                                         id="cancel-button"
//                                         color="primary"
//                                         variant="outlined"
//                                         onClick={() => this.handleCancelClick()}
//                                         disabled={!this.state.edited}
//                                     >
//                                         Cancel
//                                     </Button>
//                                     <Button
//                                         onClick={() => this.handleSaveClick()}
//                                         className={classes.fontOverride}
//                                         id="save-button"
//                                         variant="outlined"
//                                         color="secondary"
//                                         disabled={!this.state.edited}
//                                     >
//                                         Save
//                                     </Button>
//                                 </div>
//                             </div>

//                             {errorMessage && <ErrorCard errorMessage={errorMessage} />}
//                         </Fragment>
//                     )
//                 }
//             </Paper>
//         )
//     }
// }

// export default withStyles(styles)(TypeOfSale);
