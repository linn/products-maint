import { connect } from 'react-redux';
import sernosSequenceActions from '../../actions/sernosSequenceActions';
import SernosSequence from '../../components/SernosSequence';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';

const mapStateToProps = state => ({
    vatCode: {},
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state)
});

const mapDispatchToProps = {
    addItem: sernosSequenceActions.add,
    setEditStatus: sernosSequenceActions.setEditStatus
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(SernosSequence);
