import { connect } from 'react-redux';
import { fetchErrorSelectors, initialiseOnMount } from '@linn-it/linn-form-components-library';
import SalesArticle from '../../components/salesArticles/SalesArticle';
import salesArticleActions from '../../actions/salesArticle';
import salesArticleSelectors from '../../selectors/salesArticleSelectors';
import saCoreTypeActions from '../../actions/saCoreTypesActions';
import saCoreTypesSelectors from '../../selectors/saCoreTypesSelector';

const mapStateToProps = (state, { match }) => ({
    item: salesArticleSelectors.getItem(state),
    itemId: match.params.articleNumber,
    saCoreTypes: saCoreTypesSelectors.getItems(state),
    editStatus: salesArticleSelectors.getEditStatus(state),
    loading: salesArticleSelectors.getLoading(state),
    errorMessage: fetchErrorSelectors(state),
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
