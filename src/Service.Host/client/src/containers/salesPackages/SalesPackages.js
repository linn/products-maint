import { connect } from 'react-redux';
import SalesPackages from '../../components/salesPackages/SalesPackages';
import salesPackagesActions from '../../actions/salesPackages';
import initialiseOnMount from '../common/initialiseOnMount';
import salesPackagesSelectors from '../../selectors/salesPackagesSelectors';

const mapStateToProps = state => ({
    items: salesPackagesSelectors.getItems(state),
    loading: salesPackagesSelectors.getLoading(state),
    classes: {}
});

const initialise = ({ page, rowsPerPage }) => dispatch => {
    dispatch(salesPackagesActions.fetch(page, rowsPerPage));
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SalesPackages));
