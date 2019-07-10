import { connect } from 'react-redux';
import queryString from 'query-string';
import { ReportSelectors } from '@linn-it/linn-form-components-library';
import SalesArticlesByTariff from '../../components/reports/SalesArticlesByTariff';
import initialiseOnMount from '../common/initialiseOnMount';
import salesArticlesByTariffReport from '../../actions/salesArticlesByTariffReport';
import config from '../../config';

const reportSelectors = new ReportSelectors('salesArticlesByTariffReport');

const getOptions = ownProps => {
    const options = queryString.parse(ownProps.location.search);
    return options;
};

const mapStateToProps = (state, ownProps) => ({
    reportData: reportSelectors.getReportData(state),
    loading: reportSelectors.getReportLoading(state),
    options: getOptions(ownProps),
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
