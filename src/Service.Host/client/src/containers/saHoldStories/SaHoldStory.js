import { connect } from 'react-redux';
import SaHoldStory from '../../components/saHoldStories/SaHoldStory';
import initialiseOnMount from '../common/functionalInitialiseOnMount';
import saHoldStorySelectors from '../../selectors/saHoldStorySelectors';
import saHoldStoryActions from '../../actions/saHoldStoryActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';

const mapStateToProps = (state, { match }) => ({
    item: saHoldStorySelectors.getItem(state),
    editStatus: 'view',
    itemId: match.params.holdStoryId || null,
    loading: saHoldStorySelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state),
    snackbarVisible: saHoldStorySelectors.getSnackbarVisible(state)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(saHoldStoryActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    setSnackbarVisible: saHoldStoryActions.setSnackbarVisible,
    setEditStatus: saHoldStoryActions.setEditStatus
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SaHoldStory));
