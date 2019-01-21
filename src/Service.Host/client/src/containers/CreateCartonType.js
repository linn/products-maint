import React from 'react';
import { connect } from 'react-redux';
import cartonTypeActions from '../actions/cartonTypeActions';
import CartonType from '../components/CartonType';
import { getSingleErrorMessage } from '../selectors/fetchErrorSelectors';

const mapStateToProps = state => ({
    cartonType: {},
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state)
});

const mapDispatchToProps = {
    addCartonType: cartonTypeActions.add,
    resetCartonType: cartonTypeActions.reset
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(CartonType);