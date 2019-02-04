import { connect } from 'react-redux';
import StockTriggerLevelsByPart from '../../components/reports/StockTriggerLevelsByPart';
import initialiseOnMount from '../common/initialiseOnMount';
import { fetchStockTriggerLevelsByPart } from '../../actions/stockTriggerLevelsReportActions';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';

const reportName = 'stockTriggerLevelsReport';

const getPartNumber = ownProps => ownProps.match.params.partNumber;

const mapStateToProps = (state, ownProps) => ({
    reportData: getReportData(state, reportName),
    loading: getReportLoading(state, reportName),
    partNumber: getPartNumber(ownProps),
    config
});

const initialise = ({ partNumber }) => dispatch => {
    dispatch(fetchStockTriggerLevelsByPart(partNumber));
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(StockTriggerLevelsByPart));
