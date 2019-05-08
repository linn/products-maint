import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import SernosUsedOnInvoiceOptions from '../../components/reportOptions/SernosUsedOnInvoiceOptions';
import { getReportOptions } from '../../selectors/reportSelectors';

const mapStateToProps = state => ({
    prevOptions: getReportOptions(state, 'sernosUsedOnInvoiceReport')
});

export default connect(
    mapStateToProps,
    null
)(withRouter(SernosUsedOnInvoiceOptions));
