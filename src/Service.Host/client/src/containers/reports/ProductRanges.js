import { connect } from 'react-redux';
import queryString from 'query-string';
import { ReportSelectors, getItemErrorDetailMessage } from '@linn-it/linn-form-components-library';
import ProductRanges from '../../components/reports/ProductRanges';
import initialiseOnMount from '../common/initialiseOnMount';
import actions from '../../actions/productRangesReport';
import config from '../../config';
import * as reportTypes from '../../reportTypes';

const reportSelectors = new ReportSelectors(reportTypes.productRangesReport.item);

const getOptions = ownProps => {
    const query = ownProps.location.search
        ? queryString.parse(ownProps.location.search)
        : { includePhasedOut: false };
    return query;
};

const mapStateToProps = (state, ownProps) => ({
    reportData: reportSelectors.getReportData(state),
    loading: reportSelectors.getReportLoading(state),
    errorMessage: getItemErrorDetailMessage(state, reportTypes.productRangesReport.item),
    options: getOptions(ownProps),
    config
});

const initialise = ({ options }) => dispatch => {
    dispatch(actions.fetchReport(options));
};

const mapDispatchToProps = {
    initialise
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(ProductRanges));
