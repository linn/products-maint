import { connect } from 'react-redux';
import { fetchErrorSelectors, initialiseOnMount } from '@linn-it/linn-form-components-library';
import serialNumberTransactionActions from '../../actions/serialNumberTransactionActions';
import serialNumberTransCountsActions from '../../actions/serialNumberTransCountsActions';
import SerialNumberTransaction from '../../components/serialNumberTransactions/SerialNumberTransaction';
import serialNumberTransactionSelectors from '../../selectors/serialNumberTransactionSelectors';
import serialNumberTransactionCountsSelectors from '../../selectors/serialNumberTransactionCountsSelectors';

const mapStateToProps = state => ({
    item: { manualPost: 'N', updateBuiltBy: 'N' },
    editStatus: 'create',
    errorMessage: fetchErrorSelectors(state),
    sernosTransCountTypes: serialNumberTransactionCountsSelectors.getItems(state),
    loading: serialNumberTransactionSelectors.getLoading(state),
    snackbarVisible: serialNumberTransactionSelectors.getSnackbarVisible(state)
});

const initialise = () => dispatch => {
    dispatch(serialNumberTransCountsActions.fetch());
};

const mapDispatchToProps = {
    initialise,
    addSerialNumberTransaction: serialNumberTransactionActions.add,
    setEditStatus: serialNumberTransactionActions.setEditStatus,
    setSnackbarVisible: serialNumberTransactionActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SerialNumberTransaction));
