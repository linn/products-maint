import { connect } from 'react-redux';
import {
    getItemErrorDetailMessage,
    initialiseOnMount
} from '@linn-it/linn-form-components-library';
import SaHoldStory from '../../components/saHoldStories/SaHoldStory';
import saHoldStorySelectors from '../../selectors/saHoldStorySelectors';
import saHoldStoryActions from '../../actions/saHoldStoryActions';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = (state, { match }) => ({
    item: saHoldStorySelectors.getItem(state),
    editStatus: 'view',
    itemId: match.params.holdStoryId || null,
    loading: saHoldStorySelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.saHoldStory.item),
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

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(SaHoldStory));
