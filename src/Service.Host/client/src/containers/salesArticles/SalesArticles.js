import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import SalesArticles from '../../components/salesArticles/SalesArticles';
import salesArticlesActions from '../../actions/salesArticles';
import initialiseOnMount from '../common/initialiseOnMount';
import salesArticlesSelectors from '../../selectors/salesArticlesSelectors';

const mapStateToProps = (state) => ({
    items: salesArticlesSelectors.getSearchItems(state),
    loading: salesArticlesSelectors.getSearchLoading(state)
});

const mapDispatchToProps = {
    fetchItems: salesArticlesActions.search,
    clearSearch: salesArticlesActions.clearSearch,
    classes: {}
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(withRouter(initialiseOnMount(SalesArticles)));
