import { connect } from 'react-redux';
import SalesPackage from '../../components/salesPackages/SalesPackage';
import salesPackagesActions from '../../actions/salesPackage';
import initialiseOnMount from '../common/initialiseOnMount';
import salesPackagesSelectors from '../../selectors/salesPackagesSelectors';

// simple improvement might be to create these objects and have each container 
// extend them as necessary 
const mapStateToProps = (state, { match }) => ({
    item: salesPackageSelectors.getItem(state),
    itemId: match.params.id,
    editStatus: tariffSelectors.getEditStatus(state),
    errorMessage: getSingleErrorMessage(state),
    snackbarVisible: salesPackageSelectors.getSnackbarVisible(state),
    loading: salesPackagesSelectors.getLoading(state),
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
