import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import productRangeActions from '../../actions/productRange';
import ProductRange from '../../components/productRanges/ProductRange';
import initialiseOnMount from '../common/initialiseOnMount';

const mapStateToProps = state => ({
    productRange: { dateInvalid: null },
    errorMessage: fetchErrorSelectors(state),
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

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(ProductRange));
