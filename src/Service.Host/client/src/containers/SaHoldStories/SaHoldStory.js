import { connect } from 'react-redux';
import SaHoldStory from '../../components/saHoldStories/SaHoldStory';
import initialiseOnMount from '../common/initialiseOnMount';
import saHoldStorySelectors from '../../selectors/saHoldStorySelectors';
import saHoldStoryActions from '../../actions/saHoldStoryActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';

const mapStateToProps = (state, { match }) => ({
    saHoldStory: saHoldStorySelectors.getItem(state),
    id: match.params.holdStoryId,
    loading: saHoldStorySelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ id }) => dispatch => {
    dispatch(saHoldStoryActions.fetch(id));
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SaHoldStory));
