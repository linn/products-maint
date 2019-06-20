import { connect } from 'react-redux';
import { fetchErrorSelectors, initialiseOnMount } from '@linn-it/linn-form-components-library';
import SaCoreType from '../../components/SaCoreType';
import saCoreTypeActions from '../../actions/saCoreTypeActions';
import saCoreTypeSelectors from '../../selectors/saCoreTypeSelectors';

const mapStateToProps = (state, { match }) => ({
    item: saCoreTypeSelectors.getItem(state),
    itemId: match.params.coreType,
    editStatus: saCoreTypeSelectors.getEditStatus(state),
    loading: saCoreTypeSelectors.getLoading(state),
    snackbarVisible: saCoreTypeSelectors.getSnackbarVisible(state),
    errorMessage: fetchErrorSelectors(state)
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
