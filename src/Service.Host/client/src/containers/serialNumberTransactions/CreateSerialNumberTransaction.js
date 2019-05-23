import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import serialNumberTransactionActions from '../../actions/serialNumberTransactionActions';
import SerialNumberTransaction from '../../components/serialNumberTransactions/SerialNumberTransaction';
import serialNumberTransactionSelectors from '../../selectors/serialNumberTransactionSelectors';

const mapStateToProps = state => ({
    item: { manualPost: 'N', updateBuiltBy: 'N' },
    editStatus: 'create',
    errorMessage: fetchErrorSelectors(state),
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
