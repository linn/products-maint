import { connect } from 'react-redux';
import SernosSequences from '../../components/SernosSequences';
import initialiseOnMount from '../common/initialiseOnMount';
import sernosSequencesActions from '../../actions/sernosSequencesActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import sernosSequencesSelectors from '../../selectors/sernosSequencesSelectors';

const mapStateToProps = state => ({
    sernosSequences: sernosSequencesSelectors.getItems(state),
    loading: sernosSequencesSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = () => dispatch => {
    dispatch(sernosSequencesActions.fetch());
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SernosSequences));
