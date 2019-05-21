import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import { ReportSelectors } from '@linn-it/linn-form-components-library';
import ProductRangesOptions from '../../components/reportOptions/ProductRangesOptions';

const reportSelectors = new ReportSelectors('productRangesReport');

const mapStateToProps = state => ({
    prevOptions: reportSelectors.getReportOptions(state)
});

export default connect(
    mapStateToProps,
    null
)(withRouter(ProductRangesOptions));
