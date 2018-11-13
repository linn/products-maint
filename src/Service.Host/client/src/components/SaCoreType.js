import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import { Loading } from './common/Loading';

const styles = theme => ({

    textField: {

        marginLeft: '20%',
        marginRight: '20%',
        justify: 'center',
        paddingBottom: 15,
        paddingTop: 15,
        width: '60%',
        fontSize: 15


    },
    resize: {
        fontSize: 30
    },
    label:
    {
        fontSize: 15
    },
    h2: {
        marginLeft: '20%',
        marginRight: '20%',
        justify: 'center',
    }

});

class SaCoreType extends Component {
    constructor(props) {
        super(props);
        this.state = { saCoreType: this.props.saCoreType, editStatus: this.props.editStatus || 'view' };
    }

        render() {
            const { saCoreType, loading, errorMessage } = this.props;

            if (loading || !saCoreType) {
                return( 
                    errorMessage?
                    <Grid>
                    <Row>
                        <Col sm={8}>
                            <Alert style={{ marginTop: "15px" }} bsStyle="warning" >
                            <strong>{errorMessage}</strong>
                            </Alert >
                        </Col>
                    </Row>                
                    </Grid>
            :  <Loading />);
            }
            
            return (
                <div>    
                    <h2 className={this.props.classes.h2}> Sales Article Core Type Details </h2>       
                    <TextField
                        label="Core Type"
                        id="margin-normal"
                        defaultValue={saCoreType.coreType}
                        className={this.props.classes.textField}
                        InputProps={{
                            classes: {
                                input: this.props.classes.resize,
                            },
                        }}
                        helperText=""
                    />

                    <TextField
                        label="Description"
                        id="margin-normal"
                        defaultValue={saCoreType.description ? saCoreType.description : "None"}
                        className={this.props.classes.textField}
                        InputProps={{
                            classes: {
                                input: this.props.classes.resize,
                            },
                        }}
                        helperText=""
                    />

                    <TextField
                        label="Date Invalid"
                        id="margin-normal"
                        defaultValue={saCoreType.dateInvalid ? saCoreType.dateInvalid : "None"}
                        className={this.props.classes.textField}
                        InputProps={{
                            classes: {
                                input: this.props.classes.resize,
                            },
                        }}
                        helperText=""
                    />

                    <TextField
                        label="Look Ahead Days"
                        id="margin-normal"
                        defaultValue={saCoreType.lookAheadDays ? saCoreType.lookAheadDays : "None"}
                        className={this.props.classes.textField}
                        InputProps={{
                            classes: {
                                input: this.props.classes.resize,
                            },
                        }}
                        helperText=""
                    />

                    <TextField
                        label="Trigger Level"
                        id="margin-normal"
                        defaultValue={saCoreType.triggerLevel ? saCoreType.triggerLevel : "None"}
                        className={this.props.classes.textField}
                        InputProps={{
                            classes: {
                                input: this.props.classes.resize,
                            },
                        }}
                        helperText=""
                    />

                    <TextField
                        label="Sort Order"
                        id="margin-normal"
                        defaultValue={saCoreType.sortOrder ? saCoreType.sortOrder : "None"}
                        className={this.props.classes.textField}
                        InputProps={{
                            classes: {
                                input: this.props.classes.resize,
                            },
                        }}
                        helperText=""
                    />
                </div>

            );
        }
    };


SaCoreType.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(SaCoreType);