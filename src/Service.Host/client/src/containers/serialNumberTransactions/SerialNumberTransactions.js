import { connect } from 'react-redux';
import { fetchErrorSelectors, initialiseOnMount } from '@linn-it/linn-form-components-library';
import SerialNumberTransactions from '../../components/serialNumberTransactions/SerialNumberTransactions';
import serialNumberTransactionsPagedActions from '../../actions/serialNumberTransactionsPagedActions';
import serialNumberTransactionsPagedSelectors from '../../selectors/serialNumberTransactionsPagedSelectors';

const mapStateToProps = state => ({
    page: serialNumberTransactionsPagedSelectors.getPage(state),
    loading: serialNumberTransactionsPagedSelectors.getLoading(state),
    errorMessage: fetchErrorSelectors(state)
});

const pageLoad = (pageNumber = 1, rowsPerPage = 5) => dispatch => {
    dispatch(serialNumberTransactionsPagedActions.fetchPage(pageNumber, rowsPerPage));
};

const initialise = (pageNumber = 1, rowsPerPage = 5) => dispatch => {
    dispatch(serialNumberTransactionsPagedActions.fetchPage(pageNumber, rowsPerPage));
};

const mapDispatchToProps = {
    initialise,
    pageLoad
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SerialNumberTransactions));
