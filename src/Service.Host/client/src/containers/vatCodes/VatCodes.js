import { connect } from 'react-redux';
import VatCodes from '../../components/vatCodes/VatCodes';
import initialiseOnMount from '../common/initialiseOnMount';
import vatCodesActions from '../../actions/vatCodesActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import vatCodesSelectors from '../../selectors/vatCodesSelectors';

const mapStateToProps = state => ({
    vatCodes: vatCodesSelectors.getItems(state),
    loading: vatCodesSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = () => dispatch => {
    dispatch(vatCodesActions.fetch());
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(VatCodes));
