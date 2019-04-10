import { connect } from 'react-redux';
import SalesArticleCoreTypes from '../../components/reports/SalesArticleCoreTypes';
import initialiseOnMount from '../common/initialiseOnMount';
import actions from '../../actions/salesArticleCoreTypesReport';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';
import * as reportTypes from '../../reportTypes';

const reportName = reportTypes.salesArticleCoreTypes.item;

const mapStateToProps = state => ({
    reportData: getReportData(state, reportName),
    loading: getReportLoading(state, reportName),
    config
});

const initialise = () => dispatch => {
    dispatch(actions.fetchReport());
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SalesArticleCoreTypes));
