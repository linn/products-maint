import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import RootProducts from '../../components/rootProducts/RootProducts';
import rootProductsActions from '../../actions/rootProducts/rootProducts';
import initialiseOnMount from '../common/initialiseOnMount';
import rootProductsSelectors from '../../selectors/rootProducts/rootProductsSelectors';

const mapStateToProps = state => ({
    items: rootProductsSelectors.getSearchItems(state),
    loading: rootProductsSelectors.getSearchLoading(state),
    errorMessage: fetchErrorSelectors(state)
});

const mapDispatchToProps = {
    fetchItems: rootProductsActions.search,
    clearSearch: rootProductsActions.clearSearch,
    classes: {}
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(withRouter(initialiseOnMount(RootProducts)));
