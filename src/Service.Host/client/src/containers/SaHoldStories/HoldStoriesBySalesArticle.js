import { connect } from 'react-redux';
import HoldStoriesBySalesArticle from '../../components/saHoldStories/HoldStoriesBySalesArticle';
import initialiseOnMount from '../common/initialiseOnMount';
import fetchSaHoldStoriesReport from '../../actions/saHoldStoryReportActions';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';

const reportName = 'saHoldStoriesReport';
const getArticleNumber = ownProps => ownProps.match.params.articleNumber;

const mapStateToProps = (state, ownProps) => ({
    reportData: getReportData(state, reportName),
    loading: getReportLoading(state, reportName),
    articleNumber: getArticleNumber(ownProps),
    config
});

const initialise = ({ articleNumber }) => dispatch => {
    dispatch(fetchSaHoldStoriesReport(articleNumber));
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(HoldStoriesBySalesArticle));
