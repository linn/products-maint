import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import { Loading } from './common/Loading';
import { makeNumber } from '../helpers/utilities'
import moment from 'moment';
import Button from '@material-ui/core/Button';
import  DatePicker  from 'material-ui/DatePicker';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import { createMuiTheme } from '@material-ui/core/styles';
import InputLabel from '@material-ui/core/InputLabel';
import Grid from '@material-ui/core/Grid';


const styles = theme => ({

    textField: {
     
        textAlign: 'center',
        fontSize: 15,
        width: '80%'
    },

    buttonRight: {
        left: '20%',
        position: 'absolute',
    },

    buttonLeft: {
        marginTop: '20', 
        marginBottom: '40',
        right: '20%',
        position: 'absolute',
    },

    buttons: {
        paddingTop: 20
    },

    resize: {
        fontSize: 18
    },

    label: {
        fontSize: 15
    },

    h2: {
        marginLeft: '20%',
        marginRight: '20%',
        paddingBottom: 30,
        textAlign: 'center',
    },

    root: {
        position: 'absolute',
        left: '13%',
        width: '80%',
        margin: 0 +'auto',
        display: 'flex',
     
    }
});





class SaCoreType extends Component {
    constructor(props) {
        super(props);
        this.state = { saCoreType: this.props.saCoreType, editStatus: this.props.editStatus || "view" };
    }

    componentWillReceiveProps(nextProps) {
        this.setState({ editStatus: nextProps.editStatus, saCoreType: nextProps.saCoreType });
    }

    viewing() {
        return this.state.editStatus === 'view';
    }

    editing() {
        return this.state.editStatus === 'edit';
    }

    creating() {
        return this.state.editStatus === 'create';
    }

    handleSaveClick = () => {
        const { saCoreTypeId, updateSaCoreType } = this.props;
        updateSaCoreType(saCoreTypeId, this.state.saCoreType);
    }

    handleResetClick = () => {
        this.setState({ saCoreType: this.props.saCoreType })
    }

    handleAddClick = () => {
        const { addSaCoreType } = this.props;
        addSaCoreType(this.state.saCoreType);
    }

    handleCancelClick = () => {
        const { history } = this.props;
        history.push('/products/maint/sa-core-types');
    }

    handleCoreTypeChange = (e) => {
        this.setState({ saCoreType: { ...this.state.saCoreType, coreType: makeNumber(e.target.value, null) } });
    }

    handleDescriptionChange = (e) => {
        this.setState({ saCoreType: { ...this.state.saCoreType, description: e.target.value } });
    }

    handleDateInvalidChange = (e, date ) => {
        this.setState({ saCoreType: { ...this.state.saCoreType, dateInvalid: date } });
    }

    handleLookAheadDaysChange = (e) => {
        this.setState({ saCoreType: { ...this.state.saCoreType, lookAheadDays: makeNumber(e.target.value, null) } });
    }

    handleTriggerLevelChange = (e) => {
        this.setState({ saCoreType: { ...this.state.saCoreType, triggerLevel: makeNumber(e.target.value, null) } });
    }

    handleSortOrderChange = (e) => {

        this.setState({ saCoreType: { ...this.state.saCoreType, sortOrder: makeNumber(e.target.value, null) } });
    }

    render() {
        const { saCoreType, loading, errorMessage, addSaCoreType } = this.props;

        if (loading || !saCoreType) 
        {
            return (
                <Loading />);
        }

        return (
            <Grid container spacing={24} className={this.props.classes.root}>
                
                <Grid item xs={12}><h2 
                    className={this.props.classes.h2}>  
                    {this.creating() ? 
                    <span> Add Sales Article Core Type </span> : 
                    <span>Sales Article Core Type Details </span>} 
                </h2> </Grid>
                <Grid item xs={6}>
                <TextField
                    label="Core Type"
                    type="number"
                    disabled={!this.creating()}
                    id="margin-normal"
                    value={this.state.saCoreType.coreType || ''}
                    className={this.props.classes.textField}
                    InputProps={{
                        classes: {
                            input: this.props.classes.resize,
                        },
                    }}
                    InputLabelProps={{
                        shrink: true,
                        className: this.props.classes.resize,
                    }}
                    helperText={this.creating() ? "Required" : ""}
                    onChange={(e) => this.handleCoreTypeChange(e)}
                />
                </Grid>
                <Grid item xs={6}>
                <TextField
                    label="Description"
                    id="margin-normal"
                    value={this.state.saCoreType.description}
                    className={this.props.classes.textField}
                    InputProps={{
                        classes: {
                            input: this.props.classes.resize,
                        },
                    }}
                    InputLabelProps={{
                        shrink: true,
                        className: this.props.classes.resize,
                    }}
                    onChange={(e) => this.handleDescriptionChange(e)}
                /> </Grid>
              
                  
                  
                 <Grid item xs={6}>
                <TextField
                    label="Look Ahead Days"
                    id="margin-normal"
                    type="number"
                    value={this.state.saCoreType.lookAheadDays || ''}
                    className={this.props.classes.textField}
                    InputProps={{
                        classes: {
                            input: this.props.classes.resize,
                        },
                    }}
                    InputLabelProps={{
                        shrink: true,
                        className: this.props.classes.resize,
                    }}
                    onChange={(e) => this.handleLookAheadDaysChange(e)}
                />
                    </Grid>
                    <Grid item xs={6}>
                <TextField
                    label="Trigger Level"
                    id="margin-normal"
                    type="number"
                    value={this.state.saCoreType.triggerLevel || ''}
                    className={this.props.classes.textField}
                    InputProps={{
                        classes: {
                            input: this.props.classes.resize,
                        },
                    }}
                    InputLabelProps={{
                        shrink: true,
                        className: this.props.classes.resize,
                    }}
                    onChange={(e) => this.handleTriggerLevelChange(e)}
                />
                </Grid>
                <Grid item xs={6}>
                <TextField
                    label="Sort Order"
                    id="margin-normal"
                    type="number"
                    value={this.state.saCoreType.sortOrder || ''}
                    className={this.props.classes.textField}
                    InputProps={{
                        classes: {
                            input: this.props.classes.resize,
                        },
                    }}
                    InputLabelProps={{
                        shrink: true,
                        className: this.props.classes.resize,
                    }}
                    onChange={(e) => this.handleSortOrderChange(e)}
                />
                </Grid>
                <Grid item xs={6}>
                <InputLabel children="Date Invalid" className={this.props.classes.label}/>
                 { <MuiThemeProvider them={{}}>
                      <DatePicker 
                        hintText="Date Invalid"  
                        label="width: 100%;"
                        value={this.creating()? null : ( this.state.saCoreType.dateInvalid ? new Date(this.state.saCoreType.dateInvalid) : null ) }
                        formatDate={(date) => moment(date).format('DD-MM-YYYY')}
                        onChange={this.handleDateInvalidChange.bind(this)}
                    /> 
                    </MuiThemeProvider> }
                </Grid>
                <Grid item xs={6}>
               
                </Grid>  
               
                <Grid item xs={2}></Grid>
                <Grid item xs={2}></Grid>
                <Grid item xs={2}>
                <Button
                                disabled={JSON.stringify(this.state.saCoreType) === JSON.stringify(this.props.saCoreType)}
                                variant="contained" color="secondary"
                                onClick={(e) => this.handleResetClick(this.props)}
                               
                               >
                               
                                Reset
                            </Button>
                            <Button
                                disabled={JSON.stringify(this.state.saCoreType) === JSON.stringify(this.props.saCoreType)}
                                variant="contained"
                                onClick={(e) => this.handleSaveClick(e)}
                                color="primary"
                                >
                                Save
                            </Button>
               
                    
                
                </Grid>  
                
               
                 
                
                {/* {
                    this.creating() ?
                        <div className={this.props.classes.buttons}>
                            <Button
                                disabled={(this.state.saCoreType.coreType < 1) || !Number.isInteger(this.state.saCoreType.coreType)}
                                variant="contained"
                                onClick={(e) => this.handleAddClick()}
                                color="primary"
                                className={this.props.classes.buttonLeft}>
                                Add
                            </Button>

                            <Button
                                disabled={this.state.editStatus === "view"}
                                variant="contained" onClick={(e) => this.handleCancelClick()}
                                color="secondary"
                                className={this.props.classes.buttonRight}>
                                Cancel
                            </Button>
                        </div>
                        :
                        <div className={this.props.classes.buttons}>
                            
                            <Button
                                disabled={JSON.stringify(this.state.saCoreType) === JSON.stringify(this.props.saCoreType)}
                                variant="contained" color="secondary"
                                onClick={(e) => this.handleResetClick(this.props)}
                                className={this.props.classes.buttonLeft}>
                                Reset
                            </Button>

                            <Button
                                disabled={JSON.stringify(this.state.saCoreType) === JSON.stringify(this.props.saCoreType)}
                                variant="contained"
                                onClick={(e) => this.handleSaveClick(e)}
                                color="primary"
                                className={this.props.classes.buttonRight}>
                                Save
                            </Button>
                        </div>
                } */}
            </Grid>
        );
    }
};


SaCoreType.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(SaCoreType);