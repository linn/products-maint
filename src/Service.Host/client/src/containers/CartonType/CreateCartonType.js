import { connect } from 'react-redux';
import cartonTypeActions from '../../actions/cartonTypeActions';
import CartonType from '../../components/CartonType';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import cartonTypeSelectors from '../../selectors/cartonTypeSelectors';

const mapStateToProps = state => ({
    item: { height: 0, width: 0, depth: 0 },
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state),
    loading: cartonTypeSelectors.getLoading(state),
    snackbarVisible: cartonTypeSelectors.getSnackbarVisible(state)
});

const mapDispatchToProps = {
    addCartonType: cartonTypeActions.add,
    resetCartonType: cartonTypeActions.reset,
    setEditStatus: cartonTypeActions.setEditStatus,
    setSnackbarVisible: cartonTypeActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(CartonType);
