import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import { getItemErrorDetailMessage } from '@linn-it/linn-form-components-library';
import ProductRanges from '../../components/productRanges/ProductRanges';
import productRangesActions from '../../actions/productRanges';
import initialiseOnMount from '../common/initialiseOnMount';
import productRangesSelectors from '../../selectors/productRangesSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    items: productRangesSelectors.getItems(state),
    loading: productRangesSelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.productRanges.item),
    classes: {}
});

const initialise = () => dispatch => {
    dispatch(productRangesActions.fetch());
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(withRouter(initialiseOnMount(ProductRanges)));
