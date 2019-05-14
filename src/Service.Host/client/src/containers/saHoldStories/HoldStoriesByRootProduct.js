import { connect } from 'react-redux';
import HoldStories from '../../components/saHoldStories/HoldStories';
import initialiseOnMount from '../common/initialiseOnMount';
import { fetchRootProductHoldStoriesReport } from '../../actions/saHoldStoryReportActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import config from '../../config';
import { getReportData, getReportLoading } from '../../selectors/reportSelectors';

const reportName = 'saHoldStoriesReport';

const mapStateToProps = (state, { match }) => ({
    reportData: getReportData(state, reportName),
    loading: getReportLoading(state, reportName),
    errorMessage: getSingleErrorMessage(state),
    rootProduct: match.params.name,
    config
});

const initialise = ({ rootProduct }) => dispatch => {
    dispatch(fetchRootProductHoldStoriesReport(rootProduct));
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(HoldStories));
