import { connect } from 'react-redux';
import SalesArticles from '../../components/salesArticles/SalesArticles';
import { withRouter } from 'react-router'
import salesArticlesActions from '../../actions/salesArticles';
import initialiseOnMount from '../common/initialiseOnMount';
import salesArticlesSelectors from '../../selectors/salesArticlesSelectors';

const mapStateToProps = (state) => ({
    items: salesArticlesSelectors.getSearchItems(state),
    loading: salesArticlesSelectors.getSearchLoading(state)
});

const mapDispatchToProps = {
    fetchItems: salesArticlesActions.search,
    clearSearch: salesArticlesActions.clearSearch
};

export default connect(mapStateToProps, mapDispatchToProps)(withRouter(initialiseOnMount(SalesArticles)));
