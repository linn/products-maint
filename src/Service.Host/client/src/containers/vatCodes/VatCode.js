import { connect } from 'react-redux';
import { fetchErrorSelectors, initialiseOnMount } from '@linn-it/linn-form-components-library';
import VatCode from '../../components/vatCodes/VatCode';
import vatCodeActions from '../../actions/vatCodeActions';
import vatCodeSelectors from '../../selectors/vatCodeSelectors';

const mapStateToProps = (state, { match }) => ({
    item: vatCodeSelectors.getItem(state),
    itemId: match.params.vatCodeId,
    editStatus: vatCodeSelectors.getEditStatus(state),
    loading: vatCodeSelectors.getLoading(state),
    snackbarVisible: vatCodeSelectors.getSnackbarVisible(state),
    errorMessage: fetchErrorSelectors(state)
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

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(VatCode));
