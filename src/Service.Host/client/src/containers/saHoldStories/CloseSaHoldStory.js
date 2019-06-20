import { connect } from 'react-redux';
import { fetchErrorSelectors, initialiseOnMount } from '@linn-it/linn-form-components-library';
import SaHoldStory from '../../components/saHoldStories/SaHoldStory';
import saHoldStorySelectors from '../../selectors/saHoldStorySelectors';
import saHoldStoryActions from '../../actions/saHoldStoryActions';

const mapStateToProps = (state, { match }) => ({
    item: saHoldStorySelectors.getItem(state),
    editStatus: 'edit',
    itemId: match.params.holdStoryId || null,
    loading: saHoldStorySelectors.getLoading(state),
    errorMessage: fetchErrorSelectors(state),
    snackbarVisible: saHoldStorySelectors.getSnackbarVisible(state)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(saHoldStoryActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    setSnackbarVisible: saHoldStoryActions.setSnackbarVisible,
    setEditStatus: saHoldStoryActions.setEditStatus,
    updateSaHoldStory: saHoldStoryActions.update
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SaHoldStory));
