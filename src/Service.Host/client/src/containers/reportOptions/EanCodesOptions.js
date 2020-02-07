import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import { ReportSelectors } from '@linn-it/linn-form-components-library';
import EanCodesOptions from '../../components/reportOptions/EanCodesOptions';

const reportSelectors = new ReportSelectors('eanCodesReport');

const mapStateToProps = state => ({
    prevOptions: reportSelectors.getReportOptions(state)
});

export default connect(mapStateToProps, null)(withRouter(EanCodesOptions));
