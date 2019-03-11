import { connect } from 'react-redux';
import initialiseOnMount from '../common/initialiseOnMount';
import vatCodeActions from '../../actions/vatCodeActions';
import VatCode from '../../components/VatCode';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import vatCodeSelectors from '../../selectors/vatCodeSelectors';

const mapStateToProps = state => ({
    item: vatCodeSelectors.getItem(state),
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state),
    loading: vatCodeSelectors.getLoading(state),
    snackbarVisible: vatCodeSelectors.getSnackbarVisible(state)
});

const initialise = () => dispatch => {
    dispatch(vatCodeActions.setEditStatus('create'));
    dispatch(vatCodeActions.create());
};

const mapDispatchToProps = {
    initialise,
    addItem: vatCodeActions.add,
    setEditStatus: vatCodeActions.setEditStatus,
    setSnackbarVisible: vatCodeActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(VatCode));
