import { connect } from 'react-redux';
import initialiseOnMount from '../common/initialiseOnMount';
import serialNumberActions from '../../actions/serialNumberActions';
import SerialNumber from '../../components/SerialNumber';
import sernosTransactionsActions from '../../actions/sernosTransactionsActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import serialNumberSelectors from '../../selectors/serialNumberSelectors';
import sernosTransactionsSelectors from '../../selectors/sernosTransactionsSelectors';
import { getArticleType } from '../../selectors/salesArticleSelectors';
import getSalesArticleSernosDetails from '../../selectors/salesArticleSernosDetailsSelectors';
import fetchSalesArticleSernosDetails from '../../actions/salesArticleSernosDetails';

const mapStateToProps = state => ({
    item: serialNumberSelectors.getItem(state),
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state),
    loading: serialNumberSelectors.getLoading(state),
    salesArticleSernosDetails: getSalesArticleSernosDetails(state),
    sernosTransactions: sernosTransactionsSelectors.getItems(state),
    sernosTransactionsLoading: sernosTransactionsSelectors.getLoading(state),
    snackbarVisible: serialNumberSelectors.getSnackbarVisible(state),
    salesArticleType: getArticleType(state)
});

const initialise = () => dispatch => {
    dispatch(serialNumberActions.setEditStatus('create'));
    dispatch(serialNumberActions.create());
    dispatch(sernosTransactionsActions.fetch());
};

const mapDispatchToProps = {
    initialise,
    addItem: serialNumberActions.add,
    fetchSalesArticleSernosDetails,
    setEditStatus: serialNumberActions.setEditStatus,
    setSnackbarVisible: serialNumberActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SerialNumber));
