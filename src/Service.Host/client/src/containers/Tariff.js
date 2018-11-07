import { connect } from 'react-redux';
import Tariff from '../components/Tariff';
import { withRouter } from 'react-router'
import { fetchTariff } from '../actions/tariff';
import { getTariff, getTariffLoading } from '../selectors/tariffSelectors';
import initialiseOnMount from './common/initialiseOnMount';

const mapStateToProps = (state, { match }) => ({
    id: match.params.id,
    tariff: getTariff(state),
    loading: getTariffLoading(state)
});

const initialise = ({ id }) => dispatch => {
    dispatch(fetchTariff(id));
};

const mapDispatchToProps = {
    initialise
};

export default connect(mapStateToProps, mapDispatchToProps)(withRouter(initialiseOnMount(Tariff)));