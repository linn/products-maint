import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import SaHoldStoriesSearch from '../../components/saHoldStories/Search';
import salesArticlesActions from '../../actions/salesArticles';
import initialiseOnMount from '../common/initialiseOnMount';
import salesArticlesSelectors from '../../selectors/salesArticlesSelectors';

const mapStateToProps = state => {
    let items = salesArticlesSelectors.getSearchItems(state);
    items = items.map(item => ({ ...item, href: item.links[2].href }));

    return {
        items,
        loading: salesArticlesSelectors.getSearchLoading(state)
    };
};

const mapDispatchToProps = {
    fetchItems: salesArticlesActions.search,
    clearSearch: salesArticlesActions.clearSearch,
    classes: {}
};

const SaHoldStoriesCreateSearch = connect(
    mapStateToProps,
    mapDispatchToProps
)(withRouter(initialiseOnMount(SaHoldStoriesSearch)));

export default SaHoldStoriesCreateSearch;
