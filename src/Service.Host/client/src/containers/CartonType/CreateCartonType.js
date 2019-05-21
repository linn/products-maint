import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import cartonTypeActions from '../../actions/cartonTypeActions';
import CartonType from '../../components/CartonType';
import cartonTypeSelectors from '../../selectors/cartonTypeSelectors';

const mapStateToProps = state => ({
    item: {},
    editStatus: 'create',
    errorMessage: fetchErrorSelectors(state),
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
