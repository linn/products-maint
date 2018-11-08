import React from 'react';
import { connect } from 'react-redux';
import { addTariff } from '../actions/tariff';
import EditTariff from '../components/EditTariff';

const mapStateToProps = state => ({
    tariff: {},
    editStatus: 'create'
});

const mapDispatchToProps = {
    addTariff
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(EditTariff);