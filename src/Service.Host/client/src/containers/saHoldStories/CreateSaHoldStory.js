import { connect } from 'react-redux';
import { getItemErrorDetailMessage } from '@linn-it/linn-form-components-library';
import saHoldStoryActions from '../../actions/saHoldStoryActions';
import SaHoldStory from '../../components/saHoldStories/SaHoldStory';
import saHoldStorySelectors from '../../selectors/saHoldStorySelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    item: {},
    editStatus: 'create',
    errorMessage: getItemErrorDetailMessage(state, itemTypes.saHoldStory.item),
    loading: saHoldStorySelectors.getLoading(state),
    snackbarVisible: saHoldStorySelectors.getSnackbarVisible(state)
});

const mapDispatchToProps = {
    addSaHoldStory: saHoldStoryActions.add,
    resetSaHoldStory: saHoldStoryActions.reset,
    setEditStatus: saHoldStoryActions.setEditStatus,
    setSnackbarVisible: saHoldStoryActions.setSnackbarVisible
};

export default connect(mapStateToProps, mapDispatchToProps)(SaHoldStory);
