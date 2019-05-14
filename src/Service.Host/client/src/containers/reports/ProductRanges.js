import { connect } from 'react-redux';
import queryString from 'query-string';
import ProductRanges from '../../components/reports/ProductRanges';
import initialiseOnMount from '../common/initialiseOnMount';
import actions from '../../actions/productRangesReport';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';
import * as reportTypes from '../../reportTypes';

const reportName = reportTypes.productRangesReport.item;

const getOptions = ownProps => {
    const query = ownProps.location.search
        ? queryString.parse(ownProps.location.search)
        : { includePhasedOut: false };
    return query;
};

const mapStateToProps = (state, ownProps) => ({
    reportData: getReportData(state, reportName),
    loading: getReportLoading(state, reportName),
    errorMessage: getSingleErrorMessage(state),
    options: getOptions(ownProps),
    config
});

const initialise = ({ options }) => dispatch => {
    dispatch(actions.fetchReport(options));
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(ProductRanges));
