import { connect } from 'react-redux';
import { fetchErrorSelectors, initialiseOnMount } from '@linn-it/linn-form-components-library';
import SernosConfigs from '../../components/SernosConfigs';
import sernosConfigsActions from '../../actions/sernosConfigsActions';
import sernosConfigsSelectors from '../../selectors/sernosConfigsSelectors';

const mapStateToProps = state => ({
    sernosConfigs: sernosConfigsSelectors.getItems(state),
    loading: sernosConfigsSelectors.getLoading(state),
    errorMessage: fetchErrorSelectors(state)
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
