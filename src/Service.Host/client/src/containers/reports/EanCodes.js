import { connect } from 'react-redux';
import EanCodes from '../../components/reports/EanCodes';
import initialiseOnMount from '../common/initialiseOnMount';
import { fetchEanCodesReport } from '../../actions/eanCodesReport';
import queryString from 'query-string';

const getOptions = ownProps => {
    const query = ownProps.location.search ? queryString.parse(ownProps.location.search) : { includePhasedOut: false, cartonisedOnly: true };
    return query;
}

const mapStateToProps = (state, ownProps) => ({
    reportData: state.eanCodesReport.results.data,
    loading: state.eanCodesReport.results.loading,
    options: getOptions(ownProps)
});

const initialise = ({ options }) => dispatch => {
    dispatch(fetchEanCodesReport(options.includePhasedOut, options.cartonisedOnly));
};

const mapDispatchToProps = {
    initialise
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(EanCodes));