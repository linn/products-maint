import { connect } from 'react-redux';
import { fetchErrorSelectors, initialiseOnMount } from '@linn-it/linn-form-components-library';
import vatCodeActions from '../../actions/vatCodeActions';
import VatCode from '../../components/vatCodes/VatCode';
import vatCodeSelectors from '../../selectors/vatCodeSelectors';

const mapStateToProps = state => ({
    item: {},
    editStatus: 'create',
    errorMessage: fetchErrorSelectors(state),
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
