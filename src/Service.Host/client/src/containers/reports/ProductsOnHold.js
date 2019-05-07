import { connect } from 'react-redux';
import ProductsOnHold from '../../components/reports/ProductsOnHold';
import initialiseOnMount from '../common/initialiseOnMount';
import fetchProductsOnHold from '../../actions/productsOnHoldReportActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';

const reportName = 'productsOnHoldReport';

const mapStateToProps = state => ({
    reportData: getReportData(state, reportName),
    loading: getReportLoading(state, reportName),
    errorMessage: getSingleErrorMessage(state),
    config
});

const initialise = () => dispatch => {
    dispatch(fetchProductsOnHold());
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(ProductsOnHold));
