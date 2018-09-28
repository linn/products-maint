import { connect } from 'react-redux';
import SalesProductsByProductRange from '../../components/reports/SalesProductsByProductRange';
import initialiseOnMount from '../common/initialiseOnMount';
import { fetchSalesProductsByProductRangeReport } from '../../actions/salesProductsByProductRangeReport';
import queryString from 'query-string';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';

const reportName = 'salesProductsByProductRangeReport';
const getOptions = ownProps => {
    const query = ownProps.location.search ? queryString.parse(ownProps.location.search) : { includePhasedOut: false };
    return query;
}

const mapStateToProps = (state, ownProps) => ({
    reportData: getReportData(state, reportName),
    loading: getReportLoading(state, reportName),
    options: getOptions(ownProps),
    config 
});

const initialise = ({ options }) => dispatch => {
    dispatch(fetchSalesProductsByProductRangeReport(options.productRangeId, options.includePhasedOut));
};

const mapDispatchToProps = {
    initialise
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(SalesProductsByProductRange));