import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import SernosSequence from '../../components/sernosSequences/SernosSequence';
import initialiseOnMount from '../common/initialiseOnMount';
import sernosSequenceActions from '../../actions/sernosSequenceActions';
import sernosSequenceSelectors from '../../selectors/sernosSequenceSelectors';

const mapStateToProps = (state, { match }) => ({
    item: sernosSequenceSelectors.getItem(state),
    itemId: match.params.sequenceName,
    editStatus: sernosSequenceSelectors.getEditStatus(state),
    loading: sernosSequenceSelectors.getLoading(state),
    snackbarVisible: sernosSequenceSelectors.getSnackbarVisible(state),
    errorMessage: fetchErrorSelectors(state)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(sernosSequenceActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    updateItem: sernosSequenceActions.update,
    setEditStatus: sernosSequenceActions.setEditStatus,
    setSnackbarVisible: sernosSequenceActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SernosSequence));
