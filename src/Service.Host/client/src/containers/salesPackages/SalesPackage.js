import { connect } from 'react-redux';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import SalesPackage from '../../components/salesPackages/SalesPackage';
import salesPackagesActions from '../../actions/salesPackage';
import initialiseOnMount from '../common/initialiseOnMount';
import salesPackageSelectors from '../../selectors/salesPackageSelectors';

const mapStateToProps = (state, { match }) => ({
    item: salesPackageSelectors.getItem(state),
    itemId: match.params.id,
    editStatus: salesPackageSelectors.getEditStatus(state),
    errorMessage: getSingleErrorMessage(state),
    snackbarVisible: salesPackageSelectors.getSnackbarVisible(state),
    loading: salesPackageSelectors.getLoading(state),
    classes: {}
});

const initialise = () => dispatch => {
    dispatch(salesPackagesActions.fetch());
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
