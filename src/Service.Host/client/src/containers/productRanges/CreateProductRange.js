import { connect } from 'react-redux';
import { getItemErrorDetailMessage } from '@linn-it/linn-form-components-library';
import productRangeActions from '../../actions/productRange';
import ProductRange from '../../components/productRanges/ProductRange';
import initialiseOnMount from '../common/initialiseOnMount';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    productRange: { dateInvalid: null },
    errorMessage: getItemErrorDetailMessage(state, itemTypes.productRange.item),
    editStatus: 'create'
});

const initialise = () => dispatch => {
    dispatch(productRangeActions.setEditStatus('create'));
};

const mapDispatchToProps = {
    initialise,
    addProductRange: productRangeActions.add,
    resetProductRange: productRangeActions.reset,
    setEditStatus: productRangeActions.setEditStatus
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(ProductRange));
