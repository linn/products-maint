import { connect } from 'react-redux';
import SalesPackages from '../../components/salesPackages/SalesPackages';
import salesPackagesActions from '../../actions/salesPackages';
import initialiseOnMount from '../common/initialiseOnMount';
import salesPackagesSelectors from '../../selectors/salesPackagesSelectors';

const mapStateToProps = state => ({
    items: salesPackagesSelectors.getItems(state),
    rowsPerPage: salesPackagesSelectors.getRowsPerPage(state),
    page: salesPackagesSelectors.getPage(state),
    loading: salesPackagesSelectors.getLoading(state),
    classes: {}
});

const initialise = () => dispatch => {
    dispatch(salesPackagesActions.fetch());
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SalesPackages));
