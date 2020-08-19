import { connect } from 'react-redux';
import {
    getItemErrorDetailMessage,
    initialiseOnMount
} from '@linn-it/linn-form-components-library';
import Reallocator from '../../components/salesArticles/Reallocator';
import salesArticleActions from '../../actions/salesArticle';
import salesArticleSelectors from '../../selectors/salesArticleSelectors';
import saCoreTypeActions from '../../actions/saCoreTypesActions';
import saCoreTypesSelectors from '../../selectors/saCoreTypesSelector';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = (state, { match }) => ({
    item: salesArticleSelectors.getItem(state),
    itemId: match.params.articleNumber,
    saCoreTypes: saCoreTypesSelectors.getItems(state),
    editStatus: salesArticleSelectors.getEditStatus(state),
    loading: salesArticleSelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.salesArticle.item),
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

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(Reallocator));
