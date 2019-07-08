import { connect } from 'react-redux';
import { ReportSelectors } from '@linn-it/linn-form-components-library';
import SalesArticlesByTariff from '../../components/reports/SalesArticlesByTariff';
import initialiseOnMount from '../common/initialiseOnMount';
import salesArticlesByTariffReport from '../../actions/salesArticlesByTariffReport';
import config from '../../config';

const reportSelectors = new ReportSelectors('salesArticlesByTariff');

// const getOptions = ownProps => {
//     const options = ownProps.match.params;
//     return options;
// };

const mapStateToProps = (state, ownProps) => ({
    reportData: reportSelectors.getReportData(state),
    loading: reportSelectors.getReportLoading(state),
    // partNumber: getOptions(ownProps),
    config
});

const initialise = ({ options }) => dispatch => {
    dispatch(salesArticlesByTariffReport.fetchReport(options));
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SalesArticlesByTariff));
