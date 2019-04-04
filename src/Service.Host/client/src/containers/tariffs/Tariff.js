import { connect } from 'react-redux';
import Tariff from '../../components/tariffs/Tariff';
import initialiseOnMount from '../common/functionalInitialiseOnMount';
import tariffActions from '../../actions/tariff';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import tariffSelectors from '../../selectors/tariffSelectors';

const mapStateToProps = (state, { match }) => ({
    item: tariffSelectors.getItem(state),
    itemId: match.params.id,
    editStatus: tariffSelectors.getEditStatus(state),
    loading: tariffSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state),
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
