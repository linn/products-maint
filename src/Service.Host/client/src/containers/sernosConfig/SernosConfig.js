import { connect } from 'react-redux';
import SernosConfig from '../../components/SernosConfig';
import initialiseOnMount from '../common/initialiseOnMount';
import sernosConfigActions from '../../actions/sernosConfigActions';
import { getSingleErrorMessage } from '../../selectors/fetchErrorSelectors';
import sernosConfigSelectors from '../../selectors/sernosConfigSelectors';

const mapStateToProps = (state, { match }) => ({
    sernosConfig: sernosConfigSelectors.getItem(state),
    sernosConfigId: match.params.sernosConfigId,
    editStatus: sernosConfigSelectors.getEditStatus(state), 
    loading: sernosConfigSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ sernosConfigId }) => dispatch => {
    dispatch(sernosConfigActions.fetch(sernosConfigId));
};

const mapDispatchToProps = {
    initialise,
    updateSernosConfig: sernosConfigActions.update,
    resetSernosConfig: sernosConfigActions.reset
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(SernosConfig));