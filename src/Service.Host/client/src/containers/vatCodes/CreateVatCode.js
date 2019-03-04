import { connect } from 'react-redux';
import initialiseOnMount from '../common/initialiseOnMount';
import vatCodeActions from '../../actions/vatCodeActions';
import VatCode from '../../components/VatCode';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';

const mapStateToProps = state => ({
    vatCode: {},
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state)
});

const initialise = () => dispatch => {
    dispatch(vatCodeActions.setEditStatus('create'));
};

const mapDispatchToProps = {
    initialise,
    addItem: vatCodeActions.add,
    setEditStatus: vatCodeActions.setEditStatus
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(VatCode));
