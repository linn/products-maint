import { connect } from 'react-redux';
import ProductRangesOptions from '../../components/reportOptions/ProductRangesOptions';
import { withRouter } from 'react-router'
import { getReportOptions} from '../../selectors/reportSelectors';

const mapStateToProps = state => ({
    prevOptions: getReportOptions(state, 'productRangesReport')
});

export default connect(mapStateToProps, null)(withRouter(ProductRangesOptions));