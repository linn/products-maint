import { connect } from 'react-redux';
import SerialNumberTransaction from '../../components/serialNumberTransactions/SerialNumberTransaction';
import initialiseOnMount from '../common/functionalInitialiseOnMount';
import serialNumberTransactionActions from '../../actions/serialNumberTransactionActions';
import serialNumberTransactionUtilityActions from '../../actions/serialNumberTransactionUtilityActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import serialNumberTransactionSelectors from '../../selectors/serialNumberTransactionSelectors';

const mapStateToProps = (state, { match }) => ({
    itemId: match.params.id,
    item: serialNumberTransactionSelectors.getItem(state),
    sernosTransCodes: serialNumberTransactionSelectors.getSernosTransCodes(state),
    editStatus: serialNumberTransactionSelectors.getEditStatus(state),
    loading: serialNumberTransactionSelectors.getLoading(state),
    snackbarVisible: serialNumberTransactionSelectors.getSnackbarVisible(state),
    errorMessage: getSingleErrorMessage(state)
});

const fetchCodes = () => dispatch => {
    console.error('fetch those codes');
    dispatch(serialNumberTransactionUtilityActions());
};

const initialise = ({ itemId }) => dispatch => {
    dispatch(serialNumberTransactionActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    fetchCodes,
    updateSerialNumberTransaction: serialNumberTransactionActions.update,
    setEditStatus: serialNumberTransactionActions.setEditStatus,
    setSnackbarVisible: serialNumberTransactionActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SerialNumberTransaction));
