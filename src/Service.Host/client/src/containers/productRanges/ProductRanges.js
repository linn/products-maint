import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import ProductRanges from '../../components/productRanges/ProductRanges';
import productRangesActions from '../../actions/productRanges';
import initialiseOnMount from '../common/initialiseOnMount';
import productRangesSelectors from '../../selectors/productRangesSelectors';

const mapStateToProps = state => ({
    items: productRangesSelectors.getItems(state),
    loading: productRangesSelectors.getLoading(state),
    errorMessage: fetchErrorSelectors(state),
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
