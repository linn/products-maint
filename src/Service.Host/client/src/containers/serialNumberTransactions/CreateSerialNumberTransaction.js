import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import serialNumberTransactionActions from '../../actions/serialNumberTransactionActions';
import serialNumberTransactionUtilityActions from '../../actions/serialNumberTransactionUtilityActions';
import SerialNumberTransaction from '../../components/serialNumberTransactions/SerialNumberTransaction';
import serialNumberTransactionSelectors from '../../selectors/serialNumberTransactionSelectors';
import serialNumberTransactionCountsSelectors from '../../selectors/serialNumberTransactionCountsSelectors';
import initialiseOnMount from '../common/functionalInitialiseOnMount';

const mapStateToProps = state => ({
    item: { manualPost: 'N', updateBuiltBy: 'N' },
    editStatus: 'create',
    errorMessage: fetchErrorSelectors(state),
    sernosTransCountTypes: serialNumberTransactionCountsSelectors.getItems(state),
    loading: serialNumberTransactionSelectors.getLoading(state),
    snackbarVisible: serialNumberTransactionSelectors.getSnackbarVisible(state)
});

const initialise = () => dispatch => {
    dispatch(serialNumberTransactionUtilityActions.fetch());
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
