import { connect } from 'react-redux';
import { getItemErrorDetailMessage } from '@linn-it/linn-form-components-library';
import RootProduct from '../../components/rootProducts/RootProduct';
import initialiseOnMount from '../common/initialiseOnMount';
import rootProductActions from '../../actions/rootProducts/rootProduct';
import rootProductSelectors from '../../selectors/rootProducts/rootProductSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = (state, { match }) => ({
    item: rootProductSelectors.getItem(state),
    itemId: match.params.name,
    editStatus: rootProductSelectors.getEditStatus(state),
    loading: rootProductSelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state),
    snackbarVisible: rootProductSelectors.getSnackbarVisible(state, itemTypes.rootProduct.item)
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

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(RootProduct));
