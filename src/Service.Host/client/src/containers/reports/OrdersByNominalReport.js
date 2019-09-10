import { connect } from 'react-redux';
import { ReportSelectors } from '@linn-it/linn-form-components-library';
import ordersByNominalReport from '../../components/reports/OrdersByNominalReport';
import initialiseOnMount from '../common/initialiseOnMount';
import actions from '../../actions/ordersByNominalReportActions';
import config from '../../config';
import * as reportTypes from '../../reportTypes';

const reportSelectors = new ReportSelectors(reportTypes.ordersByNominalReport.item);

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
)(initialiseOnMount(ordersByNominalReport));
