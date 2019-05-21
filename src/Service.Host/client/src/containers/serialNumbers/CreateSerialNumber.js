import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import initialiseOnMount from '../common/initialiseOnMount';
import serialNumberActions from '../../actions/serialNumberActions';
import SerialNumber from '../../components/SerialNumber';
import sernosTransactionsActions from '../../actions/sernosTransactionsActions';
import serialNumberSelectors from '../../selectors/serialNumberSelectors';
import sernosTransactionsSelectors from '../../selectors/sernosTransactionsSelectors';
import getSalesArticleSernosDetails from '../../selectors/salesArticleSernosDetailsSelectors';
import salesArticlesActions from '../../actions/salesArticles';
import salesArticlesSelectors from '../../selectors/salesArticlesSelectors';
import {
    fetchSalesArticleSernosDetails,
    clearSalesArticleSernosDetails
} from '../../actions/salesArticleSernosDetails';
import sernosNotesSelectors from '../../selectors/sernosNotesSelectors';

const mapStateToProps = state => ({
    items: serialNumberSelectors.getItem(state),
    editStatus: serialNumberSelectors.getEditStatus(state),
    errorMessage: fetchErrorSelectors(state),
    loading: serialNumberSelectors.getLoading(state),
    salesArticleSernosDetails: getSalesArticleSernosDetails(state),
    sernosNotes: sernosNotesSelectors.getItems(state),
    sernosTransactions: sernosTransactionsSelectors.getItems(state),
    sernosTransactionsLoading: sernosTransactionsSelectors.getLoading(state),
    snackbarVisible: serialNumberSelectors.getSnackbarVisible(state),
    salesArticlesSearchResults: salesArticlesSelectors.getSearchItems(state),
    salesArticlesLoading: salesArticlesSelectors.getSearchLoading(state)
});

const initialise = () => dispatch => {
    dispatch(serialNumberActions.setEditStatus('create'));
    dispatch(serialNumberActions.create());
    dispatch(sernosTransactionsActions.fetch());
    dispatch(clearSalesArticleSernosDetails());
};

const mapDispatchToProps = {
    initialise,
    addItem: serialNumberActions.add,
    fetchSalesArticleSernosDetails,
    fetchSalesArticles: salesArticlesActions.search,
    setEditStatus: serialNumberActions.setEditStatus,
    setSnackbarVisible: serialNumberActions.setSnackbarVisible,
    clearSerialNumber: serialNumberActions.create,
    clearSalesArticleSernosDetails,
    clearSearch: salesArticlesActions.clearSearch
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SerialNumber));
