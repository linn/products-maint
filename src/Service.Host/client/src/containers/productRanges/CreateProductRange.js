import { connect } from 'react-redux';
import productRangeActions from '../../actions/productRange';
import ProductRange from '../../components/productRanges/ProductRange';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';

const mapStateToProps = state => ({
    productRange: { dateInvalid: null },
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state)
});

const mapDispatchToProps = {
    addProductRange: productRangeActions.add,
    resetProductRange: productRangeActions.reset,
    setEditStatus: productRangeActions.setEditStatus
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(ProductRange);
