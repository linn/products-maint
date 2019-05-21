import { connect } from 'react-redux';
import { ReportSelectors } from '@linn-it/linn-form-components-library';
import StockTriggerLevelsByPart from '../../components/reports/StockTriggerLevelsByPart';
import initialiseOnMount from '../common/initialiseOnMount';
import { fetchStockTriggerLevelsByPart } from '../../actions/stockTriggerLevelsReportActions';
import config from '../../config';

const reportSelectors = new ReportSelectors('stockTriggerLevelsReport');
const getPartNumber = ownProps => ownProps.match.params.partNumber;

const mapStateToProps = (state, ownProps) => ({
    reportData: reportSelectors.getReportData(state),
    loading: reportSelectors.getReportLoading(state),
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
