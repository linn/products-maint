import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Grid } from '@material-ui/core';
import {
    SaveBackCancelButtons,
    InputField,
    Loading,
    Title,
    ErrorCard
} from '@linn-it/linn-form-components-library';
import Page from '../containers/Page';

class CartonType extends Component {
    constructor(props) {
        super(props);
        this.handleFieldChange = this.handleFieldChange.bind(this);
        this.state = {
            editStatus: 'view',
            cartonType: null
        };
    }

    static getDerivedStateFromProps(props, state) {
        if (!state.cartonType && props.cartonType) {
            return { cartonType: props.cartonType };
        }
        return null;
    }

    handleSaveClick = () => {
        const { cartonTypeId, updateCartonType } = this.props;
        updateCartonType(cartonTypeId, { ...this.state }.cartonType);
        this.setState({ editStatus: 'view' });
    };

    handleCancelClick = () => {
        const { cartonType } = this.props;
        this.setState({ cartonType });
        this.setState({ editStatus: 'view' });
    };

    handleAddClick = () => {
        const { addCartonType } = this.props;
        const { cartonType } = this.state;
        addCartonType(cartonType);
        this.setState({ editStatus: 'view' });
    };

    handleBackClick = () => {
        this.setState({ editStatus: 'view' });
        const { history } = this.props;
        history.push('/products/reports/carton-details/report');
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
            cartonType: {
                ...prevState.cartonType,
                [propertyName]: val
            },
            editStatus: 'edit'
        }));
    }

    render() {
        const { loading, errorMessage } = this.props;
        const { cartonType } = this.state;
        if (loading || !cartonType) {
            return <Loading />;
        }

        return (
            <Page>
                <Grid container spacing={24}>
                    <Grid item xs={12}>
                        {this.creating() ? (
                            <Title text="Create Carton Type" />
                        ) : (
                            <Title text="Carton Type Details" />
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
                            value={cartonType.name}
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
                            value={cartonType.description}
                            label="Description"
                            fullWidth
                            onChange={this.handleFieldChange}
                            propertyName="description"
                        />
                    </Grid>
                    <Grid item xs={4}>
                        <InputField
                            fullWidth
                            type="number"
                            value={cartonType.width}
                            label="Width"
                            onChange={this.handleFieldChange}
                            propertyName="width"
                        />
                    </Grid>
                    <Grid item xs={4}>
                        <InputField
                            fullWidth
                            type="number"
                            value={cartonType.height}
                            label="Height"
                            onChange={this.handleFieldChange}
                            propertyName="height"
                        />
                    </Grid>
                    <Grid item xs={4}>
                        <InputField
                            fullWidth
                            type="number"
                            value={cartonType.depth}
                            label="Depth"
                            onChange={this.handleFieldChange}
                            propertyName="depth"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <SaveBackCancelButtons
                            saveDisabled={
                                !this.editing() ||
                                (!cartonType.name || cartonType.name.length === 0)
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

CartonType.defaultProps = {
    cartonType: {},
    addCartonType: null,
    updateCartonType: null,
    loading: null,
    errorMessage: '',
    cartonTypeId: null
};

CartonType.propTypes = {
    cartonType: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    cartonTypeId: PropTypes.string,
    updateCartonType: PropTypes.func,
    addCartonType: PropTypes.func,
    loading: PropTypes.bool
};

export default CartonType;



// class CartonType extends Component {
//     constructor(props) {
//         super(props);
//         this.state = {
//             cartonType: this.props.cartonType || {},
//             editStatus: this.props.editStatus || 'edit',
//             edited: false
//         };
//     }

//     static getDerivedStateFromProps(nextProps, prevState) {
//         return getSelfHref(nextProps.cartonType) !== getSelfHref(prevState.cartonType)
//             ? { cartonType: nextProps.cartonType }
//             : null;
//     }

//     handleChange(e, property) {
//         this.setState({
//             ...this.state,
//             edited: true,
//             cartonType: {
//                 ...this.state.cartonType,
//                 [property]: e.target.value
//             }
//         });
//     }

//     handleCancelClick() {
//         const { cartonType, history, resetCartonType } = this.props;
//         resetCartonType();
//         this.state.editStatus === 'create'
//             ? history.push('/products/reports/carton-details/report')
//             : this.setState({ cartonType, editStatus: 'edit', edited: false });
//     }

//     handleSaveClick() {
//         const { cartonTypeId, addCartonType, updateCartonType } = this.props;
//         this.state.editStatus === 'create'
//             ? addCartonType(this.state.cartonType)
//             : updateCartonType(cartonTypeId, this.state.cartonType);
//     }

//     render() {
//         const { cartonType, loading, classes, errorMessage } = this.props;

//         return (
//             <Paper className={classes.root}>
//                 {loading || !cartonType
//                     ? <CircularLoading />
//                     : (
//                         <Fragment>
//                             <Typography
//                                 variant="h2"
//                                 align="center"
//                                 gutterBottom
//                             >
//                                 Carton Type
//                             </Typography>
//                             <TextField
//                                 className={classes.fullWidth}
//                                 name="name"
//                                 label="Name"
//                                 value={this.state.cartonType.name || ''}
//                                 margin="normal"
//                                 variant="filled"
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
//                                 name="description"
//                                 label="Description"
//                                 value={this.state.cartonType.description || ''}
//                                 margin="normal"
//                                 variant="filled"
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
//                                 name="width"
//                                 label="Width"
//                                 type="number"
//                                 value={this.state.cartonType.width || ''}
//                                 margin="normal"
//                                 variant="filled"
//                                 InputProps={{
//                                     className: classes.fontOverride
//                                 }}
//                                 InputLabelProps={{
//                                     className: classes.fontOverride
//                                 }}
//                                 onChange={e => this.handleChange(e, 'width')}
//                             />
//                             <TextField
//                                 className={classes.fullWidth}
//                                 name="height"
//                                 label="Height"
//                                 type="number"
//                                 value={this.state.cartonType.height || ''}
//                                 margin="normal"
//                                 variant="filled"
//                                 InputProps={{
//                                     className: classes.fontOverride
//                                 }}
//                                 InputLabelProps={{
//                                     className: classes.fontOverride
//                                 }}
//                                 onChange={e => this.handleChange(e, 'height')}
//                             />
//                             <TextField
//                                 className={classes.fullWidth}
//                                 name="depth"
//                                 label="Depth"
//                                 type="number"
//                                 value={this.state.cartonType.depth || ''}
//                                 margin="normal"
//                                 variant="filled"
//                                 InputProps={{
//                                     className: classes.fontOverride
//                                 }}
//                                 InputLabelProps={{
//                                     className: classes.fontOverride
//                                 }}
//                                 onChange={e => this.handleChange(e, 'depth')}
//                             />
//                             <div style={{ marginTop: '10px' }}>
//                                 <Button
//                                     className={classes.fontOverride}
//                                     id="back-button"
//                                     component={Link}
//                                     to="/products/reports/carton-details/report"
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
//                                         disabled={!this.state.edited}
//                                         onClick={() => this.handleCancelClick()}
//                                     >
//                                         Cancel
//                                     </Button>
//                                     <Button
//                                         className={classes.fontOverride}
//                                         id="save-button"
//                                         color="secondary"
//                                         variant="outlined"
//                                         disabled={!this.state.edited}
//                                         onClick={() => this.handleSaveClick()}
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
//         );
//     }
// }

// export default withStyles(styles)(CartonType);