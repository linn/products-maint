import { connect } from 'react-redux';
import { ReportSelectors } from '@linn-it/linn-form-components-library';
import { withRouter } from 'react-router';
import WeeeReportOptions from '../../components/reportOptions/WeeeReportOptions';
import * as reportTypes from '../../reportTypes';

const reportSelectors = new ReportSelectors(reportTypes.weeeReport.item);

const mapStateToProps = state => ({
    prevOptions: reportSelectors.getReportOptions(state)
});

export default connect(mapStateToProps, null)(withRouter(WeeeReportOptions));
