import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import EanCodesOptions from '../../components/reportOptions/EanCodesOptions';
import { getReportOptions } from '../../selectors/reportSelectors';

const mapStateToProps = state => ({
    prevOptions: getReportOptions(state, 'eanCodesReport')
});

export default connect(
    mapStateToProps,
    null
)(withRouter(EanCodesOptions));
