import { connect } from 'react-redux';
import {
    getItemErrorDetailMessage,
    initialiseOnMount
} from '@linn-it/linn-form-components-library';
import VatCode from '../../components/vatCodes/VatCode';
import vatCodeActions from '../../actions/vatCodeActions';
import vatCodeSelectors from '../../selectors/vatCodeSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = (state, { match }) => ({
    item: vatCodeSelectors.getItem(state),
    itemId: match.params.vatCodeId,
    editStatus: vatCodeSelectors.getEditStatus(state),
    loading: vatCodeSelectors.getLoading(state),
    snackbarVisible: vatCodeSelectors.getSnackbarVisible(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.vatCode.item)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(vatCodeActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    updateItem: vatCodeActions.update,
    setEditStatus: vatCodeActions.setEditStatus,
    setSnackbarVisible: vatCodeActions.setSnackbarVisible
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(VatCode));
