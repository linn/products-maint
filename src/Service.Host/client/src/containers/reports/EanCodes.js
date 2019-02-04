import { connect } from 'react-redux';
import queryString from 'query-string';
import EanCodes from '../../components/reports/EanCodes';
import initialiseOnMount from '../common/initialiseOnMount';
import fetchEanCodesReport from '../../actions/eanCodesReport';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';

const reportName = 'eanCodesReport';
const getOptions = ownProps => {
    const query = ownProps.location.search ? queryString.parse(ownProps.location.search) : { includePhasedOut: false, cartonisedOnly: true };
    return query;
};

const mapStateToProps = (state, ownProps) => ({
    reportData: getReportData(state, reportName),
    loading: getReportLoading(state, reportName),
    options: getOptions(ownProps),
    config
});

const initialise = ({ options }) => dispatch => {
    dispatch(fetchEanCodesReport(options.includePhasedOut, options.cartonisedOnly));
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(EanCodes));
