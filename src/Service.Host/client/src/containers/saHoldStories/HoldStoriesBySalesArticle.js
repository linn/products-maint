import { connect } from 'react-redux';
import HoldStoriesBySalesArticle from '../../components/saHoldStories/HoldStories';
import initialiseOnMount from '../common/initialiseOnMount';
import { fetchSaHoldStoriesReport } from '../../actions/saHoldStoryReportActions';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';

const reportName = 'saHoldStoriesReport';

const mapStateToProps = (state, { match }) => ({
    reportData: getReportData(state, reportName),
    loading: getReportLoading(state, reportName),
    articleNumber: match.params.articleNumber,
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
