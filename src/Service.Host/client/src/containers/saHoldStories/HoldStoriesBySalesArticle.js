import { connect } from 'react-redux';
import { ReportSelectors, getItemErrorDetailMessage } from '@linn-it/linn-form-components-library';
import HoldStoriesBySalesArticle from '../../components/saHoldStories/HoldStories';
import initialiseOnMount from '../common/initialiseOnMount';
import { fetchSaHoldStoriesReport } from '../../actions/saHoldStoryReportActions';
import config from '../../config';

const reportSelectors = new ReportSelectors('saHoldStoriesReport');

const mapStateToProps = (state, { match }) => ({
    reportData: reportSelectors.getReportData(state),
    loading: reportSelectors.getReportLoading(state),
    errorMessage: getItemErrorDetailMessage(state, 'saHoldStoriesReport'),
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
