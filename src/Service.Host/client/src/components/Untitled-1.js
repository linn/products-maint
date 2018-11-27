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
import Grid from '@material-ui/core/Grid';


const styles = theme => ({

    textField: {
        left: '20% !important' ,
        right: '20%',
        justify: 'center',
        paddingBottom: 20,
        paddingTop: 20,
        width: '60%',
        fontSize: 15
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
        justify: 'center',
    },
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

    handleDateInvalidChange = (e) => {
        this.setState({ saCoreType: { ...this.state.saCoreType, dateInvalid: e.target.value } });
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
            <div className={this.props.classes.root}>
                
                <h2 
                    className={this.props.classes.h2}>  
                    {this.creating() ? 
                    <span> Add Sales Article Core Type </span> : 
                    <span>Sales Article Core Type Details </span>} 
                </h2>
                
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
                />
              
                  {/* <MuiThemeProvider them={{}}>
                      <DatePicker hintText="Click Here"  inputStyle={{   left: '20% !important' ,
        right: '20% !important',
        justify: 'center', postion: 'fixed'}} /> 
                    </MuiThemeProvider> */}
                  
                <TextField
                    label="Date Invalid"
                    id="margin-normal"
                    type="date"
                    value={this.creating()? "" : moment(this.state.saCoreType.dateInvalid).format('YYYY-MM-DD') }
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
                    onChange={(e) => this.handleDateInvalidChange(e)}
                />

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
                
                {
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

                            
                        </div>


                }
        );
    }
};


SaCoreType.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(SaCoreType);