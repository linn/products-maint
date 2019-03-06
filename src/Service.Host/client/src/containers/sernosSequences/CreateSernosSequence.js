import { connect } from 'react-redux';
import initialiseOnMount from '../common/initialiseOnMount';
import sernosSequenceActions from '../../actions/sernosSequenceActions';
import SernosSequence from '../../components/SernosSequence';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';

const mapStateToProps = state => ({
    sernosSequence: {},
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state)
});

const initialise = () => dispatch => {
    dispatch(sernosSequenceActions.setEditStatus('create'));
};

const mapDispatchToProps = {
    initialise,
    addItem: sernosSequenceActions.add,
    setEditStatus: sernosSequenceActions.setEditStatus
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SernosSequence));
