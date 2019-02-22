import { connect } from 'react-redux';
import SernosSequence from '../../components/SernosSequence';
import initialiseOnMount from '../common/initialiseOnMount';
import sernosSequenceActions from '../../actions/sernosSequenceActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import sernosSequenceSelectors from '../../selectors/sernosSequenceSelectors';

const mapStateToProps = (state, { match }) => ({
    sernosSequence: sernosSequenceSelectors.getItem(state),
    sequenceName: match.params.sequenceName,
    editStatus: sernosSequenceSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ sequenceName }) => dispatch => {
    dispatch(sernosSequenceActions.fetch(sequenceName));
};

const mapDispatchToProps = {
    initialise,
    updateSernosSequence: sernosSequenceActions.update,
    resetSernosSequence: sernosSequenceActions.reset,
    setEditStatus: sernosSequenceActions.setEditStatus
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SernosSequence));
