import { connect } from 'react-redux';
import SalesArticle from '../../components/salesArticles/SalesArticle';
import initialiseOnMount from '../common/initialiseOnMount';
import salesArticleActions from '../../actions/salesArticle';
import { getSingleErrorMessage } from '../../selectors/fetchErrorSelectors';
import salesArticleSelectors from '../../selectors/salesArticleSelectors';
import queryString from 'query-string';

const getArticle = location => (location.search ? queryString.parse(location.search) : null);

const mapStateToProps = (state, { location }) => ({
    salesArticle: salesArticleSelectors.getItem(state),
    id: getArticle(location).articleNumber,
    editStatus: salesArticleSelectors.getEditStatus(state),
    loading: salesArticleSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ id }) => dispatch => {
    dispatch(salesArticleActions.fetchByQueryString('articleNumber', id));
};

const mapDispatchToProps = {
    initialise,
    updateSalesArticle: salesArticleActions.update,
    resetSalesArticle: salesArticleActions.reset
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(SalesArticle));
