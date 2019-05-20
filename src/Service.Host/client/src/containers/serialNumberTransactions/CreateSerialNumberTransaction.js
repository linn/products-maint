import { connect } from 'react-redux';
import serialNumberTransactionActions from '../../actions/serialNumberTransactionActions';
import SerialNumberTransaction from '../../components/serialNumberTransactions/SerialNumberTransaction';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import serialNumberTransactionSelectors from '../../selectors/serialNumberTransactionSelectors';

const mapStateToProps = state => ({
    item: { manualPost: 'N', updateBuiltBy: 'N' },
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state),
    sernosTransCodes: serialNumberTransactionSelectors.getSernosTransCodes(state),
    loading: serialNumberTransactionSelectors.getLoading(state),
    snackbarVisible: serialNumberTransactionSelectors.getSnackbarVisible(state)
});

const mapDispatchToProps = {
    addSerialNumberTransaction: serialNumberTransactionActions.add,
    setEditStatus: serialNumberTransactionActions.setEditStatus,
    setSnackbarVisible: serialNumberTransactionActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(SerialNumberTransaction);
