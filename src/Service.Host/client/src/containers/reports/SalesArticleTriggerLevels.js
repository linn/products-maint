import { connect } from 'react-redux';
import { ReportSelectors, initialiseOnMount } from '@linn-it/linn-form-components-library';
import SalesArticleTriggerLevels from '../../components/reports/SalesArticleTriggerLevels';
import salesArticleTriggerLevelsReport from '../../actions/salesArticleTriggerLevelsReport';
import config from '../../config';

const reportSelectors = new ReportSelectors('salesArticleTriggerLevelsReport');

const mapStateToProps = state => ({
    reportData: reportSelectors.getReportData(state),
    loading: reportSelectors.getReportLoading(state),
    config
});

const initialise = () => dispatch => {
    dispatch(salesArticleTriggerLevelsReport.fetchReport());
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SalesArticleTriggerLevels));
