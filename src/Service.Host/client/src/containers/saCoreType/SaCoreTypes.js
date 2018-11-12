import { connect } from 'react-redux';
import SaCoreTypes from '../../components/SaCoreTypes';
import initialiseOnMount from '../common/initialiseOnMount';
import saCoreTypeActions from '../../actions/saCoreTypeActions';
import saCoreTypesSelectors from '../../selectors/saCoreTypesSelector';

const mapStateToProps = (state) => ({
    saCoreTypes: saCoreTypesSelectors.getItems(state),
    loading: saCoreTypesSelectors.getLoading(state)
});

const initialise = () => dispatch => {
    dispatch(saCoreTypeActions.fetch());
};

const mapDispatchToProps = {
    initialise
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(SaCoreTypes));



