import { connect } from 'react-redux';
import CartonDetails from '../../components/reports/CartonDetails';
import initialiseOnMount from '../common/initialiseOnMount';
import fetchCartonDetailsReport from '../../actions/cartonDetailsReport';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';

const reportName = 'cartonDetailsReport';

const mapStateToProps = state => ({
    reportData: getReportData(state, reportName),
    loading: getReportLoading(state, reportName),
    config
});

const initialise = () => dispatch => {
    dispatch(fetchCartonDetailsReport());
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(CartonDetails));
