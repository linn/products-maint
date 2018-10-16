import React from 'react';
import { connect } from 'react-redux';
import { addCartonType, resetCartonType } from '../actions/cartonTypes';
import CartonType from '../components/CartonType';

const mapStateToProps = state => ({
    cartonType: {},
    editStatus: 'create',
    fetchError: state.fetchError
});

const mapDispatchToProps = {
    addCartonType,
    resetCartonType
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(CartonType);