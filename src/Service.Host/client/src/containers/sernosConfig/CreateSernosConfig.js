import React from 'react';
import { connect } from 'react-redux';
import sernosConfigs from '../../actions/sernosConfigs';
import SernosConfig from '../../components/SernosConfig';
import { getSingleErrorMessage } from '../../selectors/fetchErrorSelectors';

const mapStateToProps = state => ({
    sernosConfig: {},
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state)
});

const mapDispatchToProps = {
    addSernosConfig: sernosConfigs.add,
    resetSernosConfig: sernosConfigs.reset
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(SernosConfig);