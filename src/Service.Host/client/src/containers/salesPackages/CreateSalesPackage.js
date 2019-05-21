import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import SalesPackage from '../../components/salesPackages/SalesPackage';
import salesPackagesActions from '../../actions/salesPackages/salesPackage';
import salesPackageSelectors from '../../selectors/salesPackageSelectors';

const mapStateToProps = state => ({
    item: {},
    editStatus: 'create',
    loading: salesPackageSelectors.getLoading(state),
    errorMessage: fetchErrorSelectors(state),
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
