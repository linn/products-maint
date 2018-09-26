import { connect } from 'react-redux';
import EanCodesOptions from '../../components/reportOptions/EanCodesOptions';
import { withRouter } from 'react-router'

const mapStateToProps = ({ eanCodesReport }) => ({
    prevOptions : eanCodesReport.options
});

export default connect(mapStateToProps, null)(withRouter(EanCodesOptions));