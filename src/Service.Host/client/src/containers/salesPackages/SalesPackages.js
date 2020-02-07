import { connect } from 'react-redux';
import { getItemErrorDetailMessage } from '@linn-it/linn-form-components-library';
import SalesPackages from '../../components/salesPackages/SalesPackages';
import salesPackagesActions from '../../actions/salesPackages/salesPackages';
import initialiseOnMount from '../common/initialiseOnMount';
import salesPackagesSelectors from '../../selectors/salesPackagesSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    page: salesPackagesSelectors.getPage(state),
    loading: salesPackagesSelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.salesPackage.item),
    classes: {}
});

const pageLoad = (pageNumber = 1, rowsPerPage = 10) => dispatch => {
    dispatch(salesPackagesActions.fetchPage(pageNumber, rowsPerPage));
};

const pageSortedLoad = (pageNumber = 1, rowsPerPage = 10, sortBy, asc) => dispatch => {
    dispatch(salesPackagesActions.fetchSortedPage(pageNumber, rowsPerPage, sortBy, asc));
};

const initialise = ({ pageNumber = 1, pageSize = 10 }) => dispatch => {
    dispatch(salesPackagesActions.fetchPage(pageNumber, pageSize));
};

const mapDispatchToProps = {
    initialise,
    pageLoad,
    pageSortedLoad
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(SalesPackages));
