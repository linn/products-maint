import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import ProductRangesOptions from '../../components/reportOptions/ProductRangesOptions';
import { getReportOptions } from '../../selectors/reportSelectors';

const mapStateToProps = state => ({
    prevOptions: getReportOptions(state, 'productRangesReport')
});

export default connect(
    mapStateToProps,
    null
)(withRouter(ProductRangesOptions));
