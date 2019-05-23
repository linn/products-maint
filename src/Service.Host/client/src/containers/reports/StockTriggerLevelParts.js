import { connect } from 'react-redux';
import { ReportSelectors } from '@linn-it/linn-form-components-library';
import StockTriggerLevelParts from '../../components/reports/StockTriggerLevelParts';
import initialiseOnMount from '../common/initialiseOnMount';
import { fetchStockTriggerLevelParts } from '../../actions/stockTriggerLevelsReportActions';
import config from '../../config';

const reportSelectors = new ReportSelectors('stockTriggerLevelsReport');
const getLocationId = ownProps => ownProps.match.params.locationId;

const mapStateToProps = (state, ownProps) => ({
    reportData: reportSelectors.getReportData(state),
    loading: reportSelectors.getReportLoading(state),
    locationId: getLocationId(ownProps),
    config
});

const initialise = ({ locationId }) => dispatch => {
    dispatch(fetchStockTriggerLevelParts(locationId));
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(StockTriggerLevelParts));
