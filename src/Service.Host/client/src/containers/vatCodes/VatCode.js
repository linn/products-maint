import { connect } from 'react-redux';
import VatCode from '../../components/VatCode';
import initialiseOnMount from '../common/initialiseOnMount';
import vatCodeActions from '../../actions/vatCodeActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import vatCodeSelectors from '../../selectors/vatCodeSelectors';

const mapStateToProps = (state, { match }) => ({
    vatCode: vatCodeSelectors.getItem(state),
    vatCodeId: match.params.vatCodeId,
    editStatus: vatCodeSelectors.getEditStatus(state),
    loading: vatCodeSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ vatCodeId }) => dispatch => {
    dispatch(vatCodeActions.fetch(vatCodeId));
};

const mapDispatchToProps = {
    initialise,
    updateVatCode: vatCodeActions.update,
    resetVatCode: vatCodeActions.reset
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(VatCode));
