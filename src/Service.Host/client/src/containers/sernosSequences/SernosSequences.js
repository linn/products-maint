import { connect } from 'react-redux';
import { getItemErrorDetailMessage } from '@linn-it/linn-form-components-library';
import SernosSequences from '../../components/sernosSequences/SernosSequences';
import initialiseOnMount from '../common/initialiseOnMount';
import sernosSequencesActions from '../../actions/sernosSequencesActions';
import sernosSequencesSelectors from '../../selectors/sernosSequencesSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    sernosSequences: sernosSequencesSelectors.getItems(state),
    loading: sernosSequencesSelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.sernosSequences.item)
});

const initialise = () => dispatch => {
    dispatch(sernosSequencesActions.fetch());
};

const mapDispatchToProps = {
    initialise
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(SernosSequences));
