import { connect } from 'react-redux';
import SaCoreTypes from '../../components/SaCoreTypes';
import initialiseOnMount from '../common/initialiseOnMount';
import saCoreTypesActions from '../../actions/saCoreTypesActions';
import saCoreTypesSelectors from '../../selectors/saCoreTypesSelector';

const mapStateToProps = state => ({
    saCoreTypes: saCoreTypesSelectors.getItems(state),
    loading: saCoreTypesSelectors.getLoading(state)
});

const initialise = () => dispatch => {
    dispatch(saCoreTypesActions.fetch());
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SaCoreTypes));
