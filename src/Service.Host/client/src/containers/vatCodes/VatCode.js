import { connect } from 'react-redux';
import VatCode from '../../components/VatCode';
import initialiseOnMount from '../common/initialiseOnMount';
import vatCodeActions from '../../actions/vatCodeActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import vatCodeSelectors from '../../selectors/vatCodeSelectors';

const mapStateToProps = (state, { match }) => ({
    item: vatCodeSelectors.getItem(state),
    itemId: match.params.vatCodeId,
    editStatus: vatCodeSelectors.getEditStatus(state),
    loading: vatCodeSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(vatCodeActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    addItem: vatCodeActions.add,
    updateItem: vatCodeActions.update,
    resetItem: vatCodeActions.reset,
    setEditStatus: vatCodeActions.setEditStatus
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(VatCode));
