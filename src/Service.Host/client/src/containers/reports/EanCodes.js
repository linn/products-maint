import { connect } from 'react-redux';
import queryString from 'query-string';
import { ReportSelectors } from '@linn-it/linn-form-components-library';
import EanCodes from '../../components/reports/EanCodes';
import initialiseOnMount from '../common/initialiseOnMount';
import actions from '../../actions/eanCodesReport';
import config from '../../config';
import * as reportTypes from '../../reportTypes';

const reportSelectors = new ReportSelectors(reportTypes.eanCodesReport.item);

const getOptions = ownProps => {
    const options = ownProps.location.search
        ? queryString.parse(ownProps.location.search)
        : { includePhasedOut: false, cartonisedOnly: true };
    return options;
};

const mapStateToProps = (state, ownProps) => ({
    reportData: reportSelectors.getReportData(state),
    loading: reportSelectors.getReportLoading(state),
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
