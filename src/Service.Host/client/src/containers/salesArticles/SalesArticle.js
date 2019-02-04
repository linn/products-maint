import { connect } from 'react-redux';
import SalesArticle from '../../components/salesArticles/SalesArticle';
import initialiseOnMount from '../common/initialiseOnMount';
import salesArticleActions from '../../actions/salesArticle';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import salesArticleSelectors from '../../selectors/salesArticleSelectors';

const mapStateToProps = (state, { match }) => ({
    salesArticle: salesArticleSelectors.getItem(state),
    id: match.params.articleNumber,
    editStatus: salesArticleSelectors.getEditStatus(state),
    loading: salesArticleSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ id }) => dispatch => {
    dispatch(salesArticleActions.fetch(id));
};

const mapDispatchToProps = {
    initialise,
    updateSalesArticle: salesArticleActions.update,
    resetSalesArticle: salesArticleActions.reset
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SalesArticle));
