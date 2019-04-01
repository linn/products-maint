import { connect } from 'react-redux';
import sernosConfigActions from '../../actions/sernosConfigActions';
import SernosConfig from '../../components/SernosConfig';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import sernosConfigSelectors from '../../selectors/sernosConfigSelectors';

const mapStateToProps = state => ({
    item: { serialNumbered: 'N' },
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state),
    loading: sernosConfigSelectors.getLoading(state),
    snackbarVisible: sernosConfigSelectors.getSnackbarVisible(state)
});

const mapDispatchToProps = {
    addSernosConfig: sernosConfigActions.add,
    resetSernosConfig: sernosConfigActions.reset,
    setEditStatus: sernosConfigActions.setEditStatus,
    setSnackbarVisible: sernosConfigActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(SernosConfig);
