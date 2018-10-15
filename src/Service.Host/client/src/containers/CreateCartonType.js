import React from 'react';
import { connect } from 'react-redux';
import { addCartonType } from '../actions/cartonTypes';
import CartonType from '../components/CartonType';

const mapStateToProps = state => ({
    cartonType: {},
    editStatus: 'create'
});

const mapDispatchToProps = {
    addCartonType
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(CartonType);