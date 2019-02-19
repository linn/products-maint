import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import SalesArticleCoreTypesOptions from '../../components/reportOptions/SalesArticleCoreTypesOptions';
import { getReportOptions } from '../../selectors/reportSelectors';

const mapStateToProps = state => ({
    prevOptions: getReportOptions(state, 'salesArticleCoreTypes')
});

export default connect(
    mapStateToProps,
    null
)(withRouter(SalesArticleCoreTypesOptions));
