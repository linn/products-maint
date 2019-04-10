import { connect } from 'react-redux';
import queryString from 'query-string';
import EanCodes from '../../components/reports/EanCodes';
import initialiseOnMount from '../common/initialiseOnMount';
import actions from '../../actions/eanCodesReport';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';
import * as reportTypes from '../../reportTypes';

const reportName = reportTypes.eanCodesReport.item;

const getOptions = ownProps => {
    const options = ownProps.location.search
        ? queryString.parse(ownProps.location.search)
        : { includePhasedOut: false, cartonisedOnly: true };
    return options;
};

const mapStateToProps = (state, ownProps) => ({
    reportData: getReportData(state, reportName),
    loading: getReportLoading(state, reportName),
    options: getOptions(ownProps),
    config
});

const initialise = ({ options }) => dispatch => {
    dispatch(actions.fetchReport(options));
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(EanCodes));
