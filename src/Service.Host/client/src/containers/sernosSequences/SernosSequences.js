import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import SernosSequences from '../../components/sernosSequences/SernosSequences';
import initialiseOnMount from '../common/initialiseOnMount';
import sernosSequencesActions from '../../actions/sernosSequencesActions';
import sernosSequencesSelectors from '../../selectors/sernosSequencesSelectors';

const mapStateToProps = state => ({
    sernosSequences: sernosSequencesSelectors.getItems(state),
    loading: sernosSequencesSelectors.getLoading(state),
    errorMessage: fetchErrorSelectors(state)
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
