import { connect } from 'react-redux';
import SalesArticle from '../../components/salesArticles/SalesArticle';
import initialiseOnMount from '../common/initialiseOnMount';
import salesArticleActions from '../../actions/salesArticle';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import salesArticleSelectors from '../../selectors/salesArticleSelectors';
import saCoreTypeActions from '../../actions/saCoreTypesActions';
import saCoreTypesSelectors from '../../selectors/saCoreTypesSelector';

const mapStateToProps = (state, { match }) => ({
    salesArticle: salesArticleSelectors.getItem(state),
    id: match.params.articleNumber,
    saCoreTypes: saCoreTypesSelectors.getItems(state),
    editStatus: salesArticleSelectors.getEditStatus(state),
    loading: salesArticleSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ id }) => dispatch => {
    dispatch(salesArticleActions.fetch(id));
    dispatch(saCoreTypeActions.fetch());
};

const mapDispatchToProps = {
    initialise,
    updateSalesArticle: salesArticleActions.update,
    resetSalesArticle: salesArticleActions.reset,
    setEditStatus: salesArticleActions.setEditStatus
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SalesArticle));
