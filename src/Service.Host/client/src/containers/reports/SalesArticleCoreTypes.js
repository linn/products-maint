import { connect } from 'react-redux';
import SalesArticleCoreTypes from '../../components/reports/SalesArticleCoreTypes';
import initialiseOnMount from '../common/initialiseOnMount';
import fetchReport from '../../actions/salesArticleCoreTypesReport';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';

const reportName = 'reportData';

const mapStateToProps = state => ({
    reportData: getReportData(state, reportName),
    loading: getReportLoading(state, reportName),
    config
});

const initialise = () => dispatch => {
    dispatch(fetchReport());
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SalesArticleCoreTypes));
