import { connect } from 'react-redux';
import SaCoreType from '../../components/SaCoreType';
import initialiseOnMount from '../common/initialiseOnMount';
import saCoreTypeActions from '../../actions/saCoreTypeActions'; 
import { getSingleErrorMessage } from '../../selectors/fetchErrorSelectors';
import saCoreTypeSelectors from '../../selectors/saCoreTypeSelectors'; 

const mapStateToProps = (state, { match }) => ({
    saCoreType: saCoreTypeSelectors.getItem(state),
    saCoreTypeId: match.params.coreType,
    editStatus: saCoreTypeSelectors.getEditStatus(state), 
    loading: saCoreTypeSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ saCoreTypeId }) => dispatch => {
    dispatch(saCoreTypeActions.fetch(saCoreTypeId));
};

const mapDispatchToProps = {
    initialise,
    updateSaCoreType: saCoreTypeActions.update,
    resetSaCoreType: saCoreTypeActions.reset
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(SaCoreType));
