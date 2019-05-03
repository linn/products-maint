import { connect } from 'react-redux';
import serialNumberTransactionActions from '../../actions/serialNumberTransactionActions';
import SerialNumberTransaction from '../../components/serialNumberTransactions/SerialNumberTransaction';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import serialNumberTransactionSelectors from '../../selectors/serialNumberTransactionSelectors';

const mapStateToProps = state => ({
    item: { manualPost: 'N', updateBuiltBy: 'N' },
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state),
    loading: serialNumberTransactionSelectors.getLoading(state),
    snackbarVisible: serialNumberTransactionSelectors.getSnackbarVisible(state)
});

const mapDispatchToProps = {
    addSerialNumberTransaction: serialNumberTransactionActions.add,
    resetSerialNumberTransaction: serialNumberTransactionActions.reset,
    setEditStatus: serialNumberTransactionActions.setEditStatus,
    setSnackbarVisible: serialNumberTransactionActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(SerialNumberTransaction);
