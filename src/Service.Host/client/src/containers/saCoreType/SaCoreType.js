import { connect } from 'react-redux';
import SaCoreType from '../../components/SaCoreType';
import initialiseOnMount from '../common/functionalInitialiseOnMount';
import saCoreTypeActions from '../../actions/saCoreTypeActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import saCoreTypeSelectors from '../../selectors/saCoreTypeSelectors';

const mapStateToProps = (state, { match }) => ({
    item: saCoreTypeSelectors.getItem(state),
    itemId: match.params.coreType,
    editStatus: saCoreTypeSelectors.getEditStatus(state),
    loading: saCoreTypeSelectors.getLoading(state),
    snackbarVisible: saCoreTypeSelectors.getSnackbarVisible(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(saCoreTypeActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    updateSaCoreType: saCoreTypeActions.update,
    setEditStatus: saCoreTypeActions.setEditStatus,
    resetSaCoreType: saCoreTypeActions.reset,
    setSnackbarVisible: saCoreTypeActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SaCoreType));
