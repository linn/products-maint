import { connect } from 'react-redux';
import tariff from '../components/Tariff';
import initialiseOnMount from './common/initialiseOnMount';
import tariffActions from '../actions/tariff';
import getSingleErrorMessage from '../selectors/fetchErrorSelectors';
import tariffSelectors from '../selectors/tariffSelectors';

const mapStateToProps = (state, { match }) => ({
    tariff: tariffSelectors.getItem(state),
    id: match.params.tariffCode,
    editStatus: tariffSelectors.getEditStatus(state),
    loading: tariffSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ id }) => dispatch => {
    dispatch(tariffActions.fetch(id));
};

const mapDispatchToProps = {
    initialise,
    updateTariff: tariffActions.update,
    resetTariff: tariffActions.reset
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(tariff));
