import { connect } from 'react-redux';
import EanCodes from '../../components/reports/EanCodes';
import initialiseOnMount from '../common/initialiseOnMount';
import { fetchEanCodesReport } from '../../actions/eanCodesReport';

const mapStateToProps = (state, ownProps) => ({
    reportData: state.eanCodesReport.results.data,
    loading: state.eanCodesReport.results.loading
});

const initialise = () => dispatch => {
    dispatch(fetchEanCodesReport());
};

const mapDispatchToProps = {
    initialise
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(EanCodes));