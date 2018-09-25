import { connect } from 'react-redux';
import EanCodesOptions from '../../components/reportOptions/EanCodesOptions';
import { withRouter } from 'react-router'

const mapStateToProps = ({ eanCodesReport }) => ({
    parameters : eanCodesReport.parameters,
    results: eanCodesReport.results
});

export default connect(mapStateToProps, null)(withRouter(EanCodesOptions));