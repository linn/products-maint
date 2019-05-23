import { connect } from 'react-redux';
import { ReportSelectors } from '@linn-it/linn-form-components-library';
import SalesArticleCoreTypes from '../../components/reports/SalesArticleCoreTypes';
import initialiseOnMount from '../common/initialiseOnMount';
import actions from '../../actions/salesArticleCoreTypesReport';
import config from '../../config';
import * as reportTypes from '../../reportTypes';

const reportSelectors = new ReportSelectors(reportTypes.salesArticleCoreTypes.item);

const mapStateToProps = state => ({
    reportData: reportSelectors.getReportData(state),
    loading: reportSelectors.getReportLoading(state),
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
