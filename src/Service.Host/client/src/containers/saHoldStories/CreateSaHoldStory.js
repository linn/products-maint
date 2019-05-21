import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import saHoldStoryActions from '../../actions/saHoldStoryActions';
import SaHoldStory from '../../components/saHoldStories/SaHoldStory';
import saHoldStorySelectors from '../../selectors/saHoldStorySelectors';

const mapStateToProps = state => ({
    item: {},
    editStatus: 'create',
    errorMessage: fetchErrorSelectors(state),
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
