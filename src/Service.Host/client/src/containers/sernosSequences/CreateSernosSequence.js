import { connect } from 'react-redux';
import initialiseOnMount from '../common/initialiseOnMount';
import sernosSequenceActions from '../../actions/sernosSequenceActions';
import SernosSequence from '../../components/sernosSequences/SernosSequence';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import sernosSequenceSelectors from '../../selectors/sernosSequenceSelectors';

const mapStateToProps = state => ({
    item: sernosSequenceSelectors.getItem(state),
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state),
    loading: sernosSequenceSelectors.getLoading(state),
    snackbarVisible: sernosSequenceSelectors.getSnackbarVisible(state)
});

const initialise = () => dispatch => {
    dispatch(sernosSequenceActions.setEditStatus('create'));
    dispatch(sernosSequenceActions.create());
};

const mapDispatchToProps = {
    initialise,
    addItem: sernosSequenceActions.add,
    setEditStatus: sernosSequenceActions.setEditStatus,
    setSnackbarVisible: sernosSequenceActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SernosSequence));
