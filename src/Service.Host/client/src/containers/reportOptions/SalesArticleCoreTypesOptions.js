import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import { ReportSelectors } from '@linn-it/linn-form-components-library';
import SalesArticleCoreTypesOptions from '../../components/reportOptions/SalesArticleCoreTypesOptions';

const reportSelectors = new ReportSelectors('salesArticleCoreTypes');

const mapStateToProps = state => ({
    prevOptions: reportSelectors.getReportOptions(state)
});

export default connect(
    mapStateToProps,
    null
)(withRouter(SalesArticleCoreTypesOptions));
