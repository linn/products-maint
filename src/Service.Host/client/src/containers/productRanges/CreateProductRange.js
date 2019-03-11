import { connect } from 'react-redux';
import productRangeActions from '../../actions/productRange';
import ProductRange from '../../components/productRanges/ProductRange';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import initialiseOnMount from '../common/initialiseOnMount';

const mapStateToProps = state => ({
    productRange: { dateInvalid: null },
    errorMessage: getSingleErrorMessage(state),
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
