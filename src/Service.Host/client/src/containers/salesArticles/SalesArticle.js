import { connect } from 'react-redux';
import SalesArticle from '../../components/salesArticles/SalesArticle';
import initialiseOnMount from '../common/functionalInitialiseOnMount';
import salesArticleActions from '../../actions/salesArticle';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import salesArticleSelectors from '../../selectors/salesArticleSelectors';
import saCoreTypeActions from '../../actions/saCoreTypesActions';
import saCoreTypesSelectors from '../../selectors/saCoreTypesSelector';

const mapStateToProps = (state, { match }) => ({
    item: salesArticleSelectors.getItem(state),
    itemId: match.params.articleNumber,
    saCoreTypes: saCoreTypesSelectors.getItems(state),
    editStatus: salesArticleSelectors.getEditStatus(state),
    loading: salesArticleSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state),
    snackbarVisible: salesArticleSelectors.getSnackbarVisible(state)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(salesArticleActions.fetch(itemId));
    dispatch(saCoreTypeActions.fetch());
};

const mapDispatchToProps = {
    initialise,
    updateSalesArticle: salesArticleActions.update,
    resetSalesArticle: salesArticleActions.reset,
    setEditStatus: salesArticleActions.setEditStatus,
    setSnackbarVisible: salesArticleActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SalesArticle));
