import { connect } from 'react-redux';
import { fetchErrorSelectors, initialiseOnMount } from '@linn-it/linn-form-components-library';
import Tariff from '../../components/tariffs/Tariff';
import tariffActions from '../../actions/tariff';
import tariffSelectors from '../../selectors/tariffSelectors';

const mapStateToProps = (state, { match }) => ({
    item: tariffSelectors.getItem(state),
    itemId: match.params.id,
    editStatus: tariffSelectors.getEditStatus(state),
    loading: tariffSelectors.getLoading(state),
    errorMessage: fetchErrorSelectors(state),
    snackbarVisible: tariffSelectors.getSnackbarVisible(state)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(tariffActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    updateTariff: tariffActions.update,
    addTariff: tariffActions.add,
    setEditStatus: tariffActions.setEditStatus,
    setSnackbarVisible: tariffActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(Tariff));
