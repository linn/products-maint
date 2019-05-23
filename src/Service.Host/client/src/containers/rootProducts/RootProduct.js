import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import RootProduct from '../../components/rootProducts/RootProduct';
import initialiseOnMount from '../common/initialiseOnMount';
import rootProductActions from '../../actions/rootProducts/rootProduct';
import rootProductSelectors from '../../selectors/rootProducts/rootProductSelectors';

const mapStateToProps = (state, { match }) => ({
    item: rootProductSelectors.getItem(state),
    itemId: match.params.name,
    editStatus: rootProductSelectors.getEditStatus(state),
    loading: rootProductSelectors.getLoading(state),
    errorMessage: fetchErrorSelectors(state),
    snackbarVisible: rootProductSelectors.getSnackbarVisible(state)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(rootProductActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    updateRootProduct: rootProductActions.update,
    addRootProduct: rootProductActions.add,
    setEditStatus: rootProductActions.setEditStatus,
    setSnackbarVisible: rootProductActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(RootProduct));
