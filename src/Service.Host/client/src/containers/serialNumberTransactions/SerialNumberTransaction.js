import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import SerialNumberTransaction from '../../components/serialNumberTransactions/SerialNumberTransaction';
import initialiseOnMount from '../common/functionalInitialiseOnMount';
import serialNumberTransactionActions from '../../actions/serialNumberTransactionActions';
import serialNumberTransactionUtilityActions from '../../actions/serialNumberTransactionUtilityActions';
import serialNumberTransactionSelectors from '../../selectors/serialNumberTransactionSelectors';

const mapStateToProps = (state, { match }) => ({
    itemId: match.params.id,
    item: serialNumberTransactionSelectors.getItem(state),
    sernosTransCodes: serialNumberTransactionSelectors.getSernosTransCodes(state),
    editStatus: serialNumberTransactionSelectors.getEditStatus(state),
    loading: serialNumberTransactionSelectors.getLoading(state),
    snackbarVisible: serialNumberTransactionSelectors.getSnackbarVisible(state),
    errorMessage: fetchErrorSelectors(state)
});

const fetchCodes = () => dispatch => {
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
