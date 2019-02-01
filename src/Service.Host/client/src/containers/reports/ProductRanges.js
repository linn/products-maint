import { connect } from 'react-redux';
import queryString from 'query-string';
import ProductRanges from '../../components/reports/ProductRanges';
import initialiseOnMount from '../common/initialiseOnMount';
import fetchProductRangesReport from '../../actions/productRangesReport';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';

const reportName = 'productRangesReport';
const getOptions = ownProps => {
    const query = ownProps.location.search
        ? queryString.parse(ownProps.location.search)
        : { includePhasedOut: false };
    return query;
};

const mapStateToProps = (state, ownProps) => ({
    reportData: getReportData(state, reportName),
    loading: getReportLoading(state, reportName),
    options: getOptions(ownProps),
    config
});

const initialise = ({ options }) => dispatch => {
    dispatch(fetchProductRangesReport(options.includePhasedOut));
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(ProductRanges));
