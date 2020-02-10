import { connect } from 'react-redux';
import { getItemErrorDetailMessage } from '@linn-it/linn-form-components-library';
import ProductRange from '../../components/productRanges/ProductRange';
import initialiseOnMount from '../common/initialiseOnMount';
import productRangeActions from '../../actions/productRange';
import productRangeSelectors from '../../selectors/productRangeSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = (state, { match }) => ({
    productRange: productRangeSelectors.getItem(state),
    id: Number(match.params.id),
    editStatus: productRangeSelectors.getEditStatus(state),
    loading: productRangeSelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.productRange.item)
});

const initialise = ({ id }) => dispatch => {
    dispatch(productRangeActions.fetch(id));
};

const mapDispatchToProps = {
    initialise,
    updateProductRange: productRangeActions.update,
    resetProductRange: productRangeActions.reset,
    setEditStatus: productRangeActions.setEditStatus
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(ProductRange));
