import { connect } from 'react-redux';
import SerialNumberTransaction from '../../components/serialNumberTransactions/SerialNumberTransaction';
import initialiseOnMount from '../common/functionalInitialiseOnMount';
import serialNumberTransactionActions from '../../actions/serialNumberTransactionActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import serialNumberTransactionSelectors from '../../selectors/serialNumberTransactionSelectors';

const mapStateToProps = (state, { match }) => ({
    item: serialNumberTransactionSelectors.getItem(state),
    itemId: match.params.id,
    editStatus: serialNumberTransactionSelectors.getEditStatus(state),
    loading: serialNumberTransactionSelectors.getLoading(state),
    snackbarVisible: serialNumberTransactionSelectors.getSnackbarVisible(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(serialNumberTransactionActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    updateSerialNumberTransaction: serialNumberTransactionActions.update,
    setEditStatus: serialNumberTransactionActions.setEditStatus,
    setSnackbarVisible: serialNumberTransactionActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SerialNumberTransaction));
