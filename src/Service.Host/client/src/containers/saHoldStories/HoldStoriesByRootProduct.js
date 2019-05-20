import { connect } from 'react-redux';
import { ReportSelectors } from '@linn-it/linn-form-components-library';
import HoldStories from '../../components/saHoldStories/HoldStories';
import initialiseOnMount from '../common/initialiseOnMount';
import { fetchRootProductHoldStoriesReport } from '../../actions/saHoldStoryReportActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import config from '../../config';

const reportSelectors = new ReportSelectors('saHoldStoriesReport');

const mapStateToProps = (state, { match }) => ({
    reportData: reportSelectors.getReportData(state),
    loading: reportSelectors.getReportLoading(state),
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
