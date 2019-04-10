import { connect } from 'react-redux';
import SernosConfigs from '../../components/SernosConfigs';
import initialiseOnMount from '../common/functionalInitialiseOnMount';
import sernosConfigsActions from '../../actions/sernosConfigsActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import sernosConfigsSelectors from '../../selectors/sernosConfigsSelectors';

const mapStateToProps = state => ({
    sernosConfigs: sernosConfigsSelectors.getItems(state),
    loading: sernosConfigsSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = () => dispatch => {
    dispatch(sernosConfigsActions.fetch());
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SernosConfigs));
