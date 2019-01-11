import { connect } from 'react-redux';
import SaForecasts from '../../components/salesArticles/SaForecasts';
import { withRouter } from 'react-router'
import salesArticlesActions from '../../actions/salesArticles';
import { getTariffs, getTariffsLoading } from '../../selectors/tariffSelectors';
import initialiseOnMount from '../common/initialiseOnMount';
import salesArticlesSelectors from '../../selectors/salesArticlesSelectors';

const mapStateToProps = (state) => ({
    items: salesArticlesSelectors.getSearchItems(state),
    loading: salesArticlesSelectors.getSearchLoading(state),
    title: 'Sales Article Forecast Details'
});

const mapDispatchToProps = {
    fetchItems: salesArticlesActions.search
};

export default connect(mapStateToProps, mapDispatchToProps)(withRouter(initialiseOnMount(SaForecasts)));
