import { connect } from 'react-redux';
import { ReportSelectors, fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import ProductsOnHold from '../../components/reports/ProductsOnHold';
import initialiseOnMount from '../common/initialiseOnMount';
import fetchProductsOnHold from '../../actions/productsOnHoldReportActions';
import config from '../../config';

const reportSelectors = new ReportSelectors('productsOnHoldReport');

const mapStateToProps = state => ({
    reportData: reportSelectors.getReportData(state),
    loading: reportSelectors.getReportLoading(state),
    errorMessage: fetchErrorSelectors(state),
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
