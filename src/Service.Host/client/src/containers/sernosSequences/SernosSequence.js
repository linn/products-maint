import { connect } from 'react-redux';
import SernosSequence from '../../components/SernosSequence';
import initialiseOnMount from '../common/initialiseOnMount';
import sernosSequenceActions from '../../actions/sernosSequenceActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import sernosSequenceSelectors from '../../selectors/sernosSequenceSelectors';

const mapStateToProps = (state, { match }) => ({
    item: sernosSequenceSelectors.getItem(state),
    itemId: match.params.sequenceName,
    editStatus: sernosSequenceSelectors.getEditStatus(state),
    loading: sernosSequenceSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(sernosSequenceActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    addItem: sernosSequenceActions.add,
    updateItem: sernosSequenceActions.update,
    resetItem: sernosSequenceActions.reset,
    setEditStatus: sernosSequenceActions.setEditStatus
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SernosSequence));
