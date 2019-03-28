import { connect } from 'react-redux';
import CartonType from '../../components/CartonType';
import cartonTypeActions from '../../actions/cartonTypeActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import cartonTypeSelectors from '../../selectors/cartonTypeSelectors';
import initialiseOnMount from '../common/functionalInitialiseOnMount';

const mapStateToProps = (state, { match }) => ({
    item: cartonTypeSelectors.getItem(state),
    itemId: match.params.cartonTypeId,
    editStatus: cartonTypeSelectors.getEditStatus(state),
    loading: cartonTypeSelectors.getLoading(state),
    snackbarVisible: cartonTypeSelectors.getSnackbarVisible(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(cartonTypeActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    updateCartonType: cartonTypeActions.update,
    setEditStatus: cartonTypeActions.setEditStatus,
    resetcartonType: cartonTypeActions.reset,
    setSnackbarVisible: cartonTypeActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(CartonType));
