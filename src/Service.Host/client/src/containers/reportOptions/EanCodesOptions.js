import { connect } from 'react-redux';
import EanCodesOptions from '../../components/reportOptions/EanCodesOptions';
import { withRouter } from 'react-router'
import { getReportOptions} from '../../selectors/reportSelectors';

const mapStateToProps = state => ({
    prevOptions: getReportOptions(state, 'eanCodesReport')
});

export default connect(mapStateToProps, null)(withRouter(EanCodesOptions));