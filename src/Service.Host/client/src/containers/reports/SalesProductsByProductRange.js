import { connect } from 'react-redux';
import queryString from 'query-string';
import SalesProductsByProductRange from '../../components/reports/SalesProductsByProductRange';
import initialiseOnMount from '../common/initialiseOnMount';
import actions from '../../actions/salesProductsByProductRangeReport';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';
import * as reportTypes from '../../reportTypes';

const reportName = reportTypes.salesProductsByProductRangeReport.item;

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
    dispatch(actions.fetchReport(options));
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SalesProductsByProductRange));
