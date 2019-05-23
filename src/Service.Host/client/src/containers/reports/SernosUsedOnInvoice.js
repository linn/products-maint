import { connect } from 'react-redux';
import queryString from 'query-string';
import { ReportSelectors, fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import SernosUsedOnInvoice from '../../components/reports/SernosUsedOnInvoice';
import initialiseOnMount from '../common/initialiseOnMount';
import actions from '../../actions/sernosUsedOnInvoiceReport';
import config from '../../config';
import * as reportTypes from '../../reportTypes';

const reportSelectors = new ReportSelectors(reportTypes.sernosUsedOnInvoiceReport.item);

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
    reportData: reportSelectors.getReportData(state),
    loading: reportSelectors.getReportLoading(state),
    options: getOptions(ownProps),
    errorMessage: fetchErrorSelectors(state),
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
