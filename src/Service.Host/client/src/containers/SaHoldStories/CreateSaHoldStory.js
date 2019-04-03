import { connect } from 'react-redux';
import saHoldStoryActions from '../../actions/saHoldStoryActions';
import SaHoldStory from '../../components/saHoldStories/SaHoldStory';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import saHoldStorySelectors from '../../selectors/saHoldStorySelectors';

const mapStateToProps = state => ({
    item: {},
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state),
    loading: saHoldStorySelectors.getLoading(state),
    snackbarVisible: saHoldStorySelectors.getSnackbarVisible(state)
});

const mapDispatchToProps = {
    addSaHoldStory: saHoldStoryActions.add,
    resetSaHoldStory: saHoldStoryActions.reset,
    setEditStatus: saHoldStoryActions.setEditStatus,
    setSnackbarVisible: saHoldStoryActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(SaHoldStory);
