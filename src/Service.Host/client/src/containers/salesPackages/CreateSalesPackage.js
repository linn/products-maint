import { connect } from 'react-redux';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import SalesPackage from '../../components/salesPackages/SalesPackage';
import salesPackagesActions from '../../actions/salesPackages/salesPackage';
import salesPackageSelectors from '../../selectors/salesPackageSelectors';

const mapStateToProps = state => ({
    item: {},
    editStatus: 'create',
    loading: salesPackageSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state),
    snackbarVisible: salesPackageSelectors.getSnackbarVisible(state)
});

const mapDispatchToProps = {
    add: salesPackagesActions.add,
    setSnackBarVisible: salesPackagesActions.setSnackbarVisible,
    setEditStatus: salesPackagesActions.setEditStatus
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(SalesPackage);
