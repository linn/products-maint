import { connect } from 'react-redux';
import queryString from 'query-string';
import EanCodes from '../../components/reports/EanCodes';
import initialiseOnMount from '../common/initialiseOnMount';
import { fetchEanCodesReport } from '../../actions/eanCodesReport';

const getProductUri = ownProps => {
    const query = ownProps.location.search ? queryString.parse(ownProps.location.search) : { productUri: null };
    return query.productUri;
}

const mapStateToProps = (eanCodeReports, ownProps) => ({
    eanCodeReports: eanCodeReports
});

const initialise = () => dispatch => {
    dispatch(fetchEanCodesReport());
};

const mapDispatchToProps = {
    initialise
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(EanCodes));