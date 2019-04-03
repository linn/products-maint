import { connect } from 'react-redux';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import SalesPackage from '../../components/salesPackages/SalesPackage';
import salesPackageActions from '../../actions/salesPackages';
import salesPackageSelectors from '../../selectors/salesPackageSelectors';

const mapStateToProps = state => ({
    item: {},
    editStatus: 'create',
    loading: salesPackageSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state),
    snackbarVisible: salesPackageSelectors.getSnackbarVisible(state)
});

const mapDispatchToProps = {
    add: salesPackageActions.add,
    setSnackBarVisible: salesPackageActions.setSnackbarVisible,
    setEditStatus: salesPackageActions.setEditStatus
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(SalesPackage);
