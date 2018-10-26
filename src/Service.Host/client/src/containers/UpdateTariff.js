import React from 'react';
import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import { fetchTariff, updateTariff } from '../actions/tariff';
import { getTariff, getTariffLoading } from '../selectors/tariffSelectors';
import EditTariff from '../components/EditTariff';
import initialiseOnMount from './common/initialiseOnMount';

const mapStateToProps = (state, { match })  => ({
    id: match.params.id,
    tariff: getTariff(state),
    loading: getTariffLoading(state),
    editStatus: 'edit'
});

const initialise = ({ id }) => dispatch => {
    dispatch(fetchTariff(`/products/maint/tariffs/${id}`));
};

const mapDispatchToProps = {
    initialise,
    updateTariff
}

export default connect(mapStateToProps, mapDispatchToProps)(withRouter(initialiseOnMount(EditTariff)));