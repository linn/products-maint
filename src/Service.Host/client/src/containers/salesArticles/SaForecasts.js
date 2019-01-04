import { connect } from 'react-redux';
import SaForecasts from '../../components/salesArticles/SaForecasts';
import { withRouter } from 'react-router'
import { fetchTariffs } from '../../actions/tariffs';
import { getTariffs, getTariffsLoading } from '../../selectors/tariffSelectors';
import initialiseOnMount from '../common/initialiseOnMount';

const mapStateToProps = (state) => ({
    items: getTariffs(state),
    loading: getTariffsLoading(state),
    title: 'Sales Article Forecast Details'
});

const mapDispatchToProps = {
    fetchItems: fetchTariffs
};

export default connect(mapStateToProps, mapDispatchToProps)(withRouter(initialiseOnMount(SaForecasts)));
