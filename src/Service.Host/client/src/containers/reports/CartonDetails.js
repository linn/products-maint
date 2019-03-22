import { connect } from 'react-redux';
import CartonDetails from '../../components/reports/CartonDetails';
import initialiseOnMount from '../common/initialiseOnMount';
import actions from '../../actions/cartonDetailsReport';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';
import * as reportTypes from '../../reportTypes';

const reportName = reportTypes.cartonDetailsReport.item;

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
)(initialiseOnMount(CartonDetails));
