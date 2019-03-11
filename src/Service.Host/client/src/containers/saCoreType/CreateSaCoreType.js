import { connect } from 'react-redux';
import saCoreTypeActions from '../../actions/saCoreTypeActions';
import SaCoreType from '../../components/SaCoreType';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import saCoreTypeSelectors from '../../selectors/saCoreTypeSelectors';

const mapStateToProps = state => ({
    initialSaCoreType: {},
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state),
    loading: saCoreTypeSelectors.getLoading(state),
    snackbarVisible: saCoreTypeSelectors.getSnackbarVisible(state)

});

const initialise = () => dispatch => {
    dispatch(saCoreTypeActions.setEditStatus('create'));
    dispatch(saCoreTypeActions.create());
};

const mapDispatchToProps = {
    addSaCoreType: saCoreTypeActions.add,
    resetSaCoreType: saCoreTypeActions.reset,
    setEditStatus: saCoreTypeActions.setEditStatus,
    setSnackbarVisible: saCoreTypeActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(SaCoreType);
