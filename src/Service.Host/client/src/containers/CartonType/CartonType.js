import { connect } from 'react-redux';
import { fetchErrorSelectors, initialiseOnMount } from '@linn-it/linn-form-components-library';
import CartonType from '../../components/CartonType';
import cartonTypeActions from '../../actions/cartonTypeActions';
import cartonTypeSelectors from '../../selectors/cartonTypeSelectors';

const mapStateToProps = (state, { match }) => ({
    item: cartonTypeSelectors.getItem(state),
    itemId: match.params.cartonTypeId,
    editStatus: cartonTypeSelectors.getEditStatus(state),
    loading: cartonTypeSelectors.getLoading(state),
    snackbarVisible: cartonTypeSelectors.getSnackbarVisible(state),
    errorMessage: fetchErrorSelectors(state)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(cartonTypeActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    updateCartonType: cartonTypeActions.update,
    setEditStatus: cartonTypeActions.setEditStatus,
    setSnackbarVisible: cartonTypeActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(CartonType));
