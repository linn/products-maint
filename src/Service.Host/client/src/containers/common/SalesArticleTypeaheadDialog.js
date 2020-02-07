import { connect } from 'react-redux';
import { TypeaheadDialog } from '@linn-it/linn-form-components-library';
import salesArticlesActions from '../../actions/salesArticles';
import salesArticlesSelectors from '../../selectors/salesArticlesSelectors';

const mapStateToProps = (state, { onSelect, title }) => ({
    title,
    onSelect,
    searchItems: salesArticlesSelectors
        .getSearchItems(state)
        .map(s => ({ ...s, id: s.articleNumber, name: s.articleNumber })),
    loading: salesArticlesSelectors.getSearchLoading(state)
});

const mapDispatchToProps = {
    fetchItems: salesArticlesActions.search,
    clearSearch: salesArticlesActions.clearSearch
};

export default connect(mapStateToProps, mapDispatchToProps)(TypeaheadDialog);
