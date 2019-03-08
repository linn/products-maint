import { connect } from 'react-redux';
import saCoreTypeActions from '../../actions/saCoreTypeActions';
import SaCoreType from '../../components/SaCoreType';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';

const mapStateToProps = state => ({
    initialSaCoreType: {},
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state)
});

const mapDispatchToProps = {
    addSaCoreType: saCoreTypeActions.add,
    resetSaCoreType: saCoreTypeActions.reset
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(SaCoreType);
