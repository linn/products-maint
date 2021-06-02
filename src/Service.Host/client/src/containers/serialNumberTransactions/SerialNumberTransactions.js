import { connect } from 'react-redux';
import {
    getItemErrorDetailMessage,
    initialiseOnMount
} from '@linn-it/linn-form-components-library';
import SerialNumberTransactions from '../../components/serialNumberTransactions/SerialNumberTransactions';
import serialNumberTransactionsPagedActions from '../../actions/serialNumberTransactionsPagedActions';
import serialNumberTransactionsPagedSelectors from '../../selectors/serialNumberTransactionsPagedSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    page: serialNumberTransactionsPagedSelectors.getPage(state),
    loading: serialNumberTransactionsPagedSelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.serialNumberTransaction.item)
});

const pageLoad = ({ pageNumber = 1, rowsPerPage = 10 }) => dispatch => {
    dispatch(serialNumberTransactionsPagedActions.fetchPage(pageNumber + 1, rowsPerPage));
};

const initialise = ({ pageNumber = 1, rowsPerPage = 10 }) => dispatch => {
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
