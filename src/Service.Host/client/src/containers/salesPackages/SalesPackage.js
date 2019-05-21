import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import SalesPackage from '../../components/salesPackages/SalesPackage';
import salesPackagesActions from '../../actions/salesPackages/salesPackage';
import initialiseOnMount from '../common/initialiseOnMount';
import salesPackageSelectors from '../../selectors/salesPackageSelectors';

const mapStateToProps = (state, { match }) => ({
    item: salesPackageSelectors.getItem(state),
    itemId: match.params.id,
    editStatus: salesPackageSelectors.getEditStatus(state),
    errorMessage: fetchErrorSelectors(state),
    snackbarVisible: salesPackageSelectors.getSnackbarVisible(state),
    loading: salesPackageSelectors.getLoading(state),
    classes: {}
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(salesPackagesActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    update: salesPackagesActions.update,
    add: salesPackagesActions.add,
    setEditStatus: salesPackagesActions.setEditStatus,
    setSnackbarVisible: salesPackagesActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SalesPackage));
