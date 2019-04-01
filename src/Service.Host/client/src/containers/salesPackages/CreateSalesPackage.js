import { connect } from 'react-redux';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import SalesPackage from './SalesPackage';
import SalesPackage from '../../actions/salesPackages';
import salesPackagesSelectors from '../../selectors/salesPackagesSelectors';

const mapStateToProps = state => ({
    item: {},
    editStatus: 'create',
    loading: salesPackagesSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state),
    snackbarVisible: salesPackagesSelectors.getSnackbarVisible(state)
});

const mapDispatchToProps = {
    add: salesPackageActions.add,
    setSnackBarVisible: salesPackage.setSnackbarVisible,
    setEditStatus: salesPackage.setEditStatus
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(SalesPackage);
