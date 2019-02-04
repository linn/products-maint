import { connect } from 'react-redux';
import { withRouter } from 'react-router'
import Tariffs from '../components/Tariffs';
import fetchTariffs from '../actions/tariffs';
import { getTariffs, getTariffsLoading } from '../selectors/tariffSelectors';
import initialiseOnMount from './common/initialiseOnMount';

const mapStateToProps = (state) => ({
    tariffs: getTariffs(state),
    loading: getTariffsLoading(state)
});

const mapDispatchToProps = {
    fetchTariffs
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(withRouter(initialiseOnMount(Tariffs)));
