import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import saCoreTypeActions from '../../actions/saCoreTypeActions';
import SaCoreType from '../../components/SaCoreType';
import saCoreTypeSelectors from '../../selectors/saCoreTypeSelectors';

const mapStateToProps = state => ({
    item: {},
    editStatus: 'create',
    errorMessage: fetchErrorSelectors(state),
    loading: saCoreTypeSelectors.getLoading(state),
    snackbarVisible: saCoreTypeSelectors.getSnackbarVisible(state)
});

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
