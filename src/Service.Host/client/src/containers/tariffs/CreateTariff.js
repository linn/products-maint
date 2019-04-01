import { connect } from 'react-redux';
import tariffActions from '../../actions/tariff';
import Tariff from '../../components/Tariff';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import tariffSelectors from '../../selectors/tariffSelectors';

const mapStateToProps = state => ({
    item: {},
    editStatus: 'create',
    loading: tariffSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state),
    snackbarVisible: tariffSelectors.getSnackbarVisible(state)
});

const mapDispatchToProps = {
    addTariff: tariffActions.add,
    setSnackBarVisible: tariffActions.setSnackbarVisible,
    setEditStatus: tariffActions.setEditStatus
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Tariff);
