import { connect } from 'react-redux';
import queryString from 'query-string';
import SernosUsedOnInvoice from '../../components/reports/SernosUsedOnInvoice';
import initialiseOnMount from '../common/initialiseOnMount';
import actions from '../../actions/sernosUsedOnInvoiceReport';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';
import * as reportTypes from '../../reportTypes';

const reportName = reportTypes.sernosUsedOnInvoiceReport.item;

const getOptions = ownProps => {
    const options = queryString.parse(ownProps.location.search);
    if (options.invoiceNumber === 'undefined') {
        options.invoiceNumber = '';
    }
    if (options.consignmentNumber === 'undefined') {
        options.consignmentNumber = '';
    }
    return options;
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
)(initialiseOnMount(SernosUsedOnInvoice));
