import { connect } from 'react-redux';
import SalesPackages from '../../components/salesPackages/SalesPackages';
import salesPackagesActions from '../../actions/salesPackages';
import initialiseOnMount from '../common/initialiseOnMount';
import salesPackagesSelectors from '../../selectors/salesPackagesSelectors';

const mapStateToProps = state => ({
    page: salesPackagesSelectors.getPage(state),
    loading: salesPackagesSelectors.getLoading(state),
    classes: {}
});

const pageLoad = (pageNumber = 1, rowsPerPage = 5) => dispatch => {
    dispatch(salesPackagesActions.fetch(pageNumber, rowsPerPage));
};

const initialise = ({ pageNumber, pageSize }) => dispatch => {
    dispatch(salesPackagesActions.fetch(pageNumber, pageSize));
};

const mapDispatchToProps = {
    initialise,
    pageLoad
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SalesPackages));
