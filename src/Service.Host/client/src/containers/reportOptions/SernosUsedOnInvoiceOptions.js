import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import { ReportSelectors } from '@linn-it/linn-form-components-library';
import SernosUsedOnInvoiceOptions from '../../components/reportOptions/SernosUsedOnInvoiceOptions';

const reportSelectors = new ReportSelectors('sernosUsedOnInvoiceReport');

const mapStateToProps = state => ({
    prevOptions: reportSelectors.getReportOptions(state)
});

export default connect(mapStateToProps, null)(withRouter(SernosUsedOnInvoiceOptions));
