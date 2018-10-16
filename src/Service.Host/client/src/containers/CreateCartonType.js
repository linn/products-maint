import React from 'react';
import { connect } from 'react-redux';
import { addCartonType, resetCartonType } from '../actions/cartonTypes';
import CartonType from '../components/CartonType';
import { getSingleErrorMessage } from '../selectors/fetchErrorSelectors';

const mapStateToProps = state => ({
    cartonType: {},
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state)
});

const mapDispatchToProps = {
    addCartonType,
    resetCartonType
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(CartonType);