import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import SerialNumberTransactions from '../../components/serialNumberTransactions/SerialNumberTransactions';
import initialiseOnMount from '../common/functionalInitialiseOnMount';
import serialNumberTransactionsActions from '../../actions/serialNumberTransactionsActions';
import serialNumberTransactionsSelectors from '../../selectors/serialNumberTransactionsSelectors';

const mapStateToProps = state => ({
    page: serialNumberTransactionsSelectors.getPage(state),
    loading: serialNumberTransactionsSelectors.getLoading(state),
    errorMessage: fetchErrorSelectors(state)
});

const pageLoad = (pageNumber = 1, rowsPerPage = 5) => dispatch => {
    dispatch(serialNumberTransactionsActions.fetchPage(pageNumber, rowsPerPage));
};

const initialise = (pageNumber = 1, rowsPerPage = 5) => dispatch => {
    dispatch(serialNumberTransactionsActions.fetchPage(pageNumber, rowsPerPage));
};

const mapDispatchToProps = {
    initialise,
    pageLoad
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SerialNumberTransactions));
