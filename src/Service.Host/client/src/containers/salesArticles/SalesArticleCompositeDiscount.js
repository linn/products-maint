import { connect } from 'react-redux';
import { fetchErrorSelectors, initialiseOnMount } from '@linn-it/linn-form-components-library';
import SalesArticleCompositeDiscount from '../../components/salesArticles/SalesArticleCompositeDiscount';
import salesArticleCompositeDiscountActions from '../../actions/salesArticleCompositeDiscount';
import salesArticleCompositeDiscountSelectors from '../../selectors/salesArticleCompositeDiscountSelectors';

const mapStateToProps = (state, { match }) => ({
    item: salesArticleCompositeDiscountSelectors.getItem(state),
    itemId: match.params.articleNumber,
    editStatus: salesArticleCompositeDiscountSelectors.getEditStatus(state),
    loading: salesArticleCompositeDiscountSelectors.getLoading(state),
    errorMessage: fetchErrorSelectors(state),
    snackbarVisible: salesArticleCompositeDiscountSelectors.getSnackbarVisible(state)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(salesArticleCompositeDiscountActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    updateSalesArticleCompositeDiscount: salesArticleCompositeDiscountActions.update,
    setEditStatus: salesArticleCompositeDiscountActions.setEditStatus,
    setSnackbarVisible: salesArticleCompositeDiscountActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SalesArticleCompositeDiscount));
