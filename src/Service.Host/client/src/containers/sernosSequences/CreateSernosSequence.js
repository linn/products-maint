import { connect } from 'react-redux';
import { getItemErrorDetailMessage } from '@linn-it/linn-form-components-library';
import initialiseOnMount from '../common/initialiseOnMount';
import sernosSequenceActions from '../../actions/sernosSequenceActions';
import SernosSequence from '../../components/sernosSequences/SernosSequence';
import sernosSequenceSelectors from '../../selectors/sernosSequenceSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    item: {},
    editStatus: 'create',
    errorMessage: getItemErrorDetailMessage(state, itemTypes.sernosSequence.item),
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

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(SernosSequence));
