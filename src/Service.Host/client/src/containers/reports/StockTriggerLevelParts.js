import { connect } from 'react-redux';
import StockTriggerLevelParts from '../../components/reports/StockTriggerLevelParts';
import initialiseOnMount from '../common/initialiseOnMount';
import { fetchStockTriggerLevelParts } from '../../actions/stockTriggerLevelsReportActions';
import queryString from 'query-string';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';

const reportName = 'stockTriggerLevelsReport';
const getLocationId = ownProps => {
    return ownProps.match.params.locationId;
}

const mapStateToProps = (state, ownProps) => ({
    reportData: getReportData(state, reportName),
    loading: getReportLoading(state, reportName),
    locationId: getLocationId(ownProps),
    
    config 
});

const initialise = ({locationId}) => dispatch => {
    dispatch(fetchStockTriggerLevelParts(locationId));
};

const mapDispatchToProps = {
    initialise
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(StockTriggerLevelParts));