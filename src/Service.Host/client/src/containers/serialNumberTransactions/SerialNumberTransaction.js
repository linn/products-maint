﻿import { connect } from 'react-redux';
import {
    getItemErrorDetailMessage,
    initialiseOnMount
} from '@linn-it/linn-form-components-library';
import SerialNumberTransaction from '../../components/serialNumberTransactions/SerialNumberTransaction';
import serialNumberTransactionActions from '../../actions/serialNumberTransactionActions';
import serialNumberTransCountsActions from '../../actions/serialNumberTransCountsActions';
import serialNumberTransactionSelectors from '../../selectors/serialNumberTransactionSelectors';
import serialNumberTransactionCountsSelectors from '../../selectors/serialNumberTransactionCountsSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = (state, { match }) => ({
    itemId: match.params.id,
    item: serialNumberTransactionSelectors.getItem(state),
    sernosTransCountTypes: serialNumberTransactionCountsSelectors.getItems(state),
    editStatus: serialNumberTransactionSelectors.getEditStatus(state),
    loading: serialNumberTransactionSelectors.getLoading(state),
    snackbarVisible: serialNumberTransactionSelectors.getSnackbarVisible(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.serialNumberTransaction.item)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(serialNumberTransactionActions.fetch(itemId));
    dispatch(serialNumberTransCountsActions.fetch());
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
